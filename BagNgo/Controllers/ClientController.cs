using BagNgo.Helpers;
using BagNgo.ViewModels.Implementation;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BagNgo.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors(origins: "http://localhost:4200", headers: "", methods: "*")]
    [ApiController]

    public class ClientControllers : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Users> userManager;
        private readonly IUserService userService;
        private readonly SignInManager<Users> signInManager;
        private readonly IClientservice clientService;
        private readonly IHostService hostService;
        private readonly ICommercantService commercantService;
        private readonly IPhotoService photoservice;
        private readonly IEmailSender _emailSender;
        private readonly ICommentService commentService;
        private readonly ApplicationDbContext _DBContext;


        IConfiguration configuration;

        public ClientControllers(RoleManager<IdentityRole> roleManager, UserManager<Users> _userManager,
            IUserService _UserService, SignInManager<Users> _signInManager, IConfiguration _configuration,
            IClientservice _clientService, IHostService _hostService, ICommercantService _commercantService, ICommentService _commentService,
            IEmailSender emailSender, IPhotoService _phoroservice, ApplicationDbContext _dbcontext)
        {
            this.roleManager = roleManager;
            userManager = _userManager;
            userService = _UserService;
            signInManager = _signInManager;
            this.configuration = _configuration;
            clientService = _clientService;
            commentService = _commentService;
            hostService = _hostService;
            commercantService = _commercantService;
            _emailSender = emailSender;
            photoservice = _phoroservice;
            _DBContext = _dbcontext;
        }

        [HttpGet("Exist")]
        public bool CheckEmail(string email)
        {
            var result = _DBContext.User.ToList().Exists(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
            return result;
        }
        [HttpGet("ConfirmedEmail")]
        public Task<bool> CheckEmailConfirm(string email)
        {
            // var user =  userService.FindByMail(email);
            var result = userService.GetUserEmailValidation(email);
            return result;


        }

        [HttpPost("LogoutClient")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            {
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(10)
                };
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, authProperties);
                return Ok();
            }


        }
        //[AllowCrossSiteJson]
        [HttpPost("LoginClient")]
        public async Task<ActionResult<AuthenticationResponseViewModel>> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.rememberMe, false);

                if (result.Succeeded)
                {

                    var user = await userService.FindByMail(model.Email);

                    if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                    {
                        IList<string> roles = await userManager.GetRolesAsync(user);

                        List<Claim> authClaims = new List<Claim>();

                        foreach (string role in roles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        authClaims.Add(new Claim(ClaimTypes.Actor, user.Email));

                        SymmetricSecurityKey authkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

                        JwtSecurityToken token = new JwtSecurityToken(
                            issuer: "",
                            audience: "",
                            claims: authClaims,
                            expires: DateTime.Now.AddYears(100),
                            signingCredentials: new SigningCredentials(authkey, SecurityAlgorithms.HmacSha256)

                            );

                        var newToken = token.Claims.FirstOrDefault().Value.ToString();

                        return new AuthenticationResponseViewModel()
                        {

                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expiration = token.ValidTo,
                            Role = newToken.ToString(),
                            Id = user.Id,
                        };

                    }
                    else

                        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    return StatusCode(StatusCodes.Status200OK);
                }
            }
            return StatusCode(StatusCodes.Status404NotFound);

        }

        [AllowCrossSiteJson]
        [HttpPost("RegisterClient")]
        // [Authorize(Roles = "Client")]
        public async Task<ActionResult> RegisterClient([FromBody] ClientViewModel model)
        {


            if (model.Password != model.ConfirmPassword)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe et la confirmation ne sont pas identique" });
            }

            if (ModelState.IsValid)
            {
                if (EmailExistes(model.Email))
                {
                    return BadRequest("Email is used");
                }

                var user = new Client
                {
                    UserName = model.Email,
                    Password = model.Password,
                    Email = model.Email,
                    Adresse = model.Adresse,
                    Country = model.Country,
                    ConfirmPassword = model.ConfirmPassword,
                    //Photo = model.Photo,

                    Telephone = model.Telephone,
                    DateOfBirth = model.DateOfBirth,
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    NormalizedEmail = model.Email,
                    //  PhotoLink = img.FileName,

                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    if (await roleManager.RoleExistsAsync("Client"))
                    {
                        await userManager.AddToRoleAsync(user, "Client");
                    }
                    else
                    {
                        IdentityRole identityrole = new IdentityRole
                        {
                            Name = "Client"

                        };
                        await roleManager.CreateAsync(identityrole);
                        await userManager.AddToRoleAsync(user, "Client");

                    }


                    if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                    {
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var param = new Dictionary<string, string?>
                                {
                                {"token", token },
                                {"email", user.Email }
                                };
                        var callback = QueryHelpers.AddQueryString("http://localhost:4200/emailconfirmation", param);

                        var message = new Message(new string[] { user.Email }, "Email Confirmation token", callback);
                        // return Ok(message);
                        await _emailSender.SendEmailAsync(message);

                        return Ok("Check your Email for Confirmation");
                    }

                }

                else
                {
                    return BadRequest("errr");
                }

            }
            return StatusCode(StatusCodes.Status200OK);
        }

        private bool EmailExistes(string email)
        {
            return userManager.Users.Any(x => x.Email == email);
        }

        [AllowCrossSiteJson]
        [HttpPost("RegisterHost")]
        // [Authorize(Roles = "Host")]
        public async Task<ActionResult> RegisterHost(HostViewModel model)
        {
            string att = "En Attente";
            if (model.Password != model.ConfirmPassword)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe et la confirmation ne sont pas identique" });
            }
            if (EmailExistes(model.Email))
            {
                return BadRequest("Host Email is used");
            }
            if (ModelState.IsValid)
            {

                var user = new Hote
                {
                    PersAContact = model.PersAContact,
                    Type = model.Type,
                    NumCnss = model.NumCnss,
                    ZipCode = model.ZipCode,
                    TaxNum = model.TaxNum,
                    Country = model.Country,
                    ConfirmPassword = model.ConfirmPassword,
                    UserName = model.Email,
                    Password = model.Password,
                    Email = model.Email,
                    Adresse = model.Adresse,
                    Telephone = model.Telephone,
                    FemaleWorkforce = model.FemaleWorkforce,
                    MaleWorkforce = model.MaleWorkforce,
                    LegalName = model.LegalName,
                    Gouvernorate = model.Gouvernorate,
                    Verified = att,
                    Delegation = model.Delegation,


                };

                IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (await roleManager.RoleExistsAsync("Host"))
                    {
                        await userManager.AddToRoleAsync(user, "Host");
                    }
                    else
                    {
                        IdentityRole identityrole = new IdentityRole
                        {
                            Name = "Host"

                        };
                        await roleManager.CreateAsync(identityrole);
                        await userManager.AddToRoleAsync(user, "Host");

                    }

                    if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                    {

                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var param = new Dictionary<string, string>
                                {
                                {"token", token },
                                {"email", user.Email }
                                };
                        var callback = QueryHelpers.AddQueryString("http://localhost:4200/emailconfirmation", param);
                        var message = new Message(new string[] { user.Email }, "Email Confirmation token", callback);
                        await _emailSender.SendEmailAsync(message);

                        return Ok("token was send succesfully");
                    }

                }

                else
                {
                    return BadRequest(result.Errors);
                }

            }
            return StatusCode(StatusCodes.Status200OK);
        }

        [AllowCrossSiteJson]
        [HttpPost("RegisterCommercant")]
        // [Authorize(Roles = "Commercant")]
        public async Task<ActionResult> RegisterCommercant(CommercantViewModel model)
        {
            string att = "En Attente";
            if (model.Password != model.ConfirmPassword)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe et la confirmation ne sont pas identique" });
            }

            if (ModelState.IsValid)
            {

                var user = new Commercant
                {
                    PersAContact = model.PersAContact,
                    NumCnss = model.NumCnss,
                    ZipCode = model.ZipCode,
                    TaxNum = model.TaxNum,
                    Country = model.Country,
                    ConfirmPassword = model.ConfirmPassword,
                    UserName = model.Email,
                    Password = model.Password,
                    Email = model.Email,
                    Adresse = model.Adresse,
                    Telephone = model.Telephone,
                    FemaleWorkforce = model.FemaleWorkforce,
                    MaleWorkforce = model.MaleWorkforce,
                    LegalName = model.LegalName,
                    BasicActivity = model.BasicActivity,
                    Gouvernorate = model.Gouvernorate,
                    LegalStatus = model.LegalStatus,
                    TypeService = model.TypeService,
                    RestaurantSpeciality = model.RestaurantSpeciality,
                    RestaurantType = model.RestaurantType,
                    Verified = att,
                    Delegation = model.Delegation,

                };

                IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (await roleManager.RoleExistsAsync("Commercant"))
                    {
                        await userManager.AddToRoleAsync(user, "Commercant");
                    }
                    else
                    {
                        IdentityRole identityrole = new IdentityRole
                        {
                            Name = "Commercant"

                        };
                        await roleManager.CreateAsync(identityrole);
                        await userManager.AddToRoleAsync(user, "Commercant");

                    }


                    if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                    {

                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var param = new Dictionary<string, string>
                                {
                                {"token", token },
                                {"email", user.Email }
                                };
                        var callback = QueryHelpers.AddQueryString("http://localhost:4200/emailconfirmation", param);
                        var message = new Message(new string[] { user.Email }, "Email Confirmation token", callback);
                        await _emailSender.SendEmailAsync(message);

                        return Ok("token was send succesfully");
                    }

                }

                else
                {
                    return BadRequest(result.Errors);
                }

            }
            return StatusCode(StatusCodes.Status200OK);
        }


        [HttpGet("GetRoleById")]
        public async Task<ActionResult<RoleViewModel>> GetRoleNameById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var roles = await userManager.GetRolesAsync(user);

            return Ok(roles);
        }


        [HttpPut("EditClient/{id}")]
        public async Task<ActionResult<EditClientViewModel>> EditClient(EditClientViewModel model, string id)
        {

            var client = await clientService.GetClientById(id);
            Console.WriteLine(" Controller client : {0}", client);
            if (client == null)
            {
                return NotFound("Client not found");
            }
            else
            {

                client.Adresse = model.Adresse;
                client.Country = model.Country;
                client.Telephone = model.Telephone;
                client.DateOfBirth = model.DateOfBirth;
                client.Nom = model.Nom;
                client.Prenom = model.Prenom;



            }
            await clientService.UpdateClientAsync(id, client);

            return new EditClientViewModel()
            {

                Adresse = client.Adresse,
                Country = client.Country,
                Telephone = client.Telephone,
                DateOfBirth = client.DateOfBirth,
                Nom = client.Nom,
                Prenom = client.Prenom,

            };
        }

        [HttpPatch("UpdateHost/{id}")]
        public async Task<ActionResult> UpdateHost(string id, [FromBody] JsonPatchDocument hostPatch)
        {


            var host = await hostService.GetHostById(id);
            Console.WriteLine(" Controller Host : {0}", host);
            if (host == null)
            {
                return NotFound("Host not found");
            }
            await hostService.UpdateHostAsync(id, hostPatch);
            return Ok();
        }

        [HttpPut("EditHost/{id}")]
        public async Task<ActionResult<EditHostViewModel>> EditHost(EditHostViewModel model, string id)
        {

            var host = await hostService.GetHostById(id);
            Console.WriteLine(" Controller client : {0}", host);
            if (host == null)
            {
                return NotFound("Host not found");
            }
            else
            {


                host.PersAContact = model.PersAContact;
                host.ZipCode = model.ZipCode;
                host.CINCopy = model.CINCopy;
                host.TaxNum = model.TaxNum;
                host.Country = model.Country;
                host.Adresse = model.Adresse;
                host.NumCnss = model.NumCnss;
                host.Telephone = model.Telephone;
                host.Gouvernorate = model.Gouvernorate;
                host.LegalName = model.LegalName;
                host.RNECopy = model.RNECopy;
                host.LicenceCopy = model.LicenceCopy;
                host.Verified = "En Attente";
                host.MaleWorkforce = model.MaleWorkforce;
                host.FemaleWorkforce = model.FemaleWorkforce;
                host.Delegation = model.Delegation;

            }
            await hostService.PutHostAsync(id, host);

            return new EditHostViewModel()
            {
                PersAContact = model.PersAContact,
                ZipCode = model.ZipCode,
                CINCopy = model.CINCopy,
                TaxNum = model.TaxNum,
                Country = model.Country,
                Adresse = model.Adresse,
                NumCnss = model.NumCnss,
                Telephone = model.Telephone,
                Gouvernorate = model.Gouvernorate,
                LegalName = model.LegalName,
                RNECopy = model.RNECopy,
                LicenceCopy = model.LicenceCopy,
                MaleWorkforce = model.MaleWorkforce,
                FemaleWorkforce = model.FemaleWorkforce,
                Verified = "En Attente",
                Delegation = model.Delegation,

            };
        }

        [HttpPut("EditCommercant/{id}")]
        public async Task<ActionResult<EditCommercantViewModel>> EditCommercant(EditCommercantViewModel model, string id)
        {

            var commercant = await commercantService.GetCommercantById(id);
            Console.WriteLine(" Controller client : {0}", commercant);
            if (commercant == null)
            {
                return NotFound("Commercant not found");
            }
            else
            {


                commercant.PersAContact = model.PersAContact;
                commercant.ZipCode = model.ZipCode;
                commercant.CINCopy = model.CINCopy;
                commercant.TaxNum = model.TaxNum;
                commercant.Country = model.Country;
                commercant.Adresse = model.Adresse;
                commercant.NumCnss = model.NumCnss;
                commercant.Telephone = model.Telephone;
                commercant.Gouvernorate = model.Gouvernorate;
                commercant.LegalName = model.LegalName;
                commercant.RNECopy = model.RNECopy;
                commercant.LicenceCopy = model.LicenceCopy;
                commercant.Verified = "En Attente";
                commercant.MaleWorkforce = model.MaleWorkforce;
                commercant.FemaleWorkforce = model.FemaleWorkforce;
                commercant.TypeService = model.TypeService;
                commercant.RestaurantSpeciality = model.RestaurantSpeciality;
                commercant.RestaurantType = model.RestaurantType;
                commercant.LegalStatus = model.LegalStatus;
                commercant.BasicActivity = model.BasicActivity;
                commercant.CADTouristTraansp = commercant.CADTouristTraansp;
                commercant.Delegation = model.Delegation;


            }
            await commercantService.UpdateCommercantAsync(id, commercant);

            return new EditCommercantViewModel()
            {

                PersAContact = model.PersAContact,
                ZipCode = model.ZipCode,
                CINCopy = model.CINCopy,
                TaxNum = model.TaxNum,
                Country = model.Country,
                Adresse = model.Adresse,
                NumCnss = model.NumCnss,
                Telephone = model.Telephone,
                Gouvernorate = model.Gouvernorate,
                LegalName = model.LegalName,
                RNECopy = model.RNECopy,
                LicenceCopy = model.LicenceCopy,
                MaleWorkforce = model.MaleWorkforce,
                FemaleWorkforce = model.FemaleWorkforce,
                Verified = "En Attente",
                RestaurantType = model.RestaurantType,
                TypeService = model.TypeService,
                RestaurantSpeciality = model.RestaurantSpeciality,
                LegalStatus = model.LegalStatus,
                BasicActivity = model.BasicActivity,
                CADTouristTraansp = model.CADTouristTraansp,
                Delegation = model.Delegation,

            };
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string>
              {
                {"token", token },
                {"email", model.Email }
            };

            var callback = QueryHelpers.AddQueryString(model.ClientURI, param);

            var message = new Message(new string[] { user.Email }, "Reset password token", callback);
            await _emailSender.SendEmailAsync(message);

            return Ok();
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel resetPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await userManager.FindByNameAsync(resetPasswordDto.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            if (!resetPassResult.Succeeded)
            {
                var errors = resetPassResult.Errors.Select(e => e.Description);

                return BadRequest(new { Errors = errors });
            }

            return Ok();
        }

        [HttpGet("EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string email, [FromQuery] string token)
        {
            if (email == null)
                return BadRequest("Invalid Email");
            if (token == null)
                return BadRequest("Invalid Token");
            var user = await userManager.FindByNameAsync(email);
            if (user == null)
                return BadRequest("Invalid Email Confirmation Request");

            var confirmResult = await userManager.ConfirmEmailAsync(user, token);
            if (!confirmResult.Succeeded)
                return BadRequest("Invalid Email Confirmation");

            return Ok();
        }
        [HttpPost("AddPhoto")]
        public async Task<ActionResult<PhotosViewModel>> AddPhoto(IFormFile file, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await userManager.FindByNameAsync(Email);
            //return Ok(user.Id);
            if (user.PhotoLink != null)
                return BadRequest(StatusCodes.Status409Conflict);

            if (user.PhotoLink == null)
            {
                var result = await photoservice.AddPhotoAsync(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new Photo
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    TypeFile = "ProfilePic",
                    //   IsMain = true,
                    UserId = user.Id,
                };

                user.PhotoLink = photo.Url.ToString();
                //user.Photos.Add(photo);
                await userManager.UpdateAsync(user);
                await photoservice.InsertPhoto(photo);

                return new PhotosViewModel()
                {
                    //IsMain = true,
                    Url = photo.Url,
                    TypeFile = photo.TypeFile,
                    //Id = photo.Id,
                    UserId = photo.UserId,
                    //PublicId = photo.PublicId,
                };
            }

            return BadRequest("Photo Added successfully");

        }
        [HttpPost("AddRNEFile")]
        public async Task<ActionResult<PhotosViewModel>> AddRNEFile(IFormFile file, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await userManager.FindByNameAsync(Email);
            var role = await userManager.GetRolesAsync(user1);
            //return Ok(role);
            if (role.Contains("Commercant"))
            {
                var user = await commercantService.GetCommercantByEmail(Email);
                if (user.RNECopy != null)
                    return BadRequest(StatusCodes.Status409Conflict);

                if (user.RNECopy == null)
                {
                    var result = await photoservice.AddRNEFilesAsync(file);
                    if (result.Error != null)
                        return BadRequest(StatusCodes.Status404NotFound);

                    var photo = new Photo
                    {

                        Url = result.SecureUrl.AbsoluteUri,
                        PublicId = result.PublicId,
                        TypeFile = "RNEFile",
                        //   IsMain = true,
                        UserId = user.Id,
                    };

                    user.RNECopy = photo.Url.ToString();
                    // user.Photos.Add(photo);
                    await userManager.UpdateAsync(user);
                    await photoservice.InsertPhoto(photo);
                }
            }

            if (role.Contains("Host"))
            {
                var user = await hostService.GetHostByEmail(Email);
                if (user.RNECopy != null)
                    return BadRequest(StatusCodes.Status409Conflict);

                if (user.RNECopy == null)
                {
                    var result = await photoservice.AddRNEFilesAsync(file);
                    if (result.Error != null)
                        return BadRequest(StatusCodes.Status404NotFound);

                    var photo = new Photo
                    {

                        Url = result.SecureUrl.AbsoluteUri,
                        PublicId = result.PublicId,
                        TypeFile = "RNEFile",
                        //   IsMain = true,
                        UserId = user.Id,
                    };
                    user.RNECopy = photo.Url.ToString();
                    // user.Photos.Add(photo);
                    await userManager.UpdateAsync(user);
                    await photoservice.InsertPhoto(photo);
                }
            }

            return Ok("RNE Added Successfully");

        }
        [HttpPost("AddCINFile")]
        public async Task<ActionResult<PhotosViewModel>> AddCINFile(IFormFile file, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await userManager.FindByNameAsync(Email);
            var role = await userManager.GetRolesAsync(user1);
            //return Ok(role);
            if (role.Contains("Host"))
            {
                var user = await hostService.GetHostByEmail(Email);
                if (user.CINCopy != null)
                    return BadRequest(StatusCodes.Status409Conflict);
                if (user.CINCopy == null)
                {
                    var result = await photoservice.AddIDFilesAsync(file);
                    if (result.Error != null)
                        return BadRequest(StatusCodes.Status404NotFound);

                    var photo = new Photo
                    {

                        Url = result.SecureUrl.AbsoluteUri,
                        PublicId = result.PublicId,
                        TypeFile = "CIN Copy",
                        //   IsMain = true,
                        UserId = user.Id,
                    };
                    user.CINCopy = photo.Url.ToString();
                    // user.Photos.Add(photo);
                    await userManager.UpdateAsync(user);
                    await photoservice.InsertPhoto(photo);
                }
            }

            return Ok("CIN Added Successfully");

        }
        [HttpPost("AddLicenceFile")]
        public async Task<ActionResult<PhotosViewModel>> AddLicenceFile(IFormFile file, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await userManager.FindByNameAsync(Email);
            var role = await userManager.GetRolesAsync(user1);
            //return Ok(role);
            if (role.Contains("Commercant"))
            {
                var user = await commercantService.GetCommercantByEmail(Email);
                if (user.LicenceCopy != null)
                    return BadRequest(StatusCodes.Status409Conflict);

                if (user.LicenceCopy == null)
                {
                    var result = await photoservice.AddLicenceFilesAsync(file);
                    if (result.Error != null)
                        return BadRequest(StatusCodes.Status404NotFound);

                    var photo = new Photo
                    {

                        Url = result.SecureUrl.AbsoluteUri,
                        PublicId = result.PublicId,
                        TypeFile = "Licence File",
                        //   IsMain = true,
                        UserId = user.Id,
                    };

                    user.LicenceCopy = photo.Url.ToString();
                    // user.Photos.Add(photo);
                    await userManager.UpdateAsync(user);
                    await photoservice.InsertPhoto(photo);
                }
            }

            if (role.Contains("Host"))
            {
                var user = await hostService.GetHostByEmail(Email);
                if (user.LicenceCopy != null)
                    return BadRequest(StatusCodes.Status409Conflict);

                if (user.LicenceCopy == null)
                {
                    var result = await photoservice.AddLicenceFilesAsync(file);
                    if (result.Error != null)
                        return BadRequest(StatusCodes.Status404NotFound);

                    var photo = new Photo
                    {

                        Url = result.SecureUrl.AbsoluteUri,
                        PublicId = result.PublicId,
                        TypeFile = "Licence File",
                        //   IsMain = true,
                        UserId = user.Id,
                    };
                    user.LicenceCopy = photo.Url.ToString();
                    // user.Photos.Add(photo);
                    await userManager.UpdateAsync(user);
                    await photoservice.InsertPhoto(photo);
                }
            }

            return Ok("Licence Added Successfully");

        }
        [HttpPost("AddCADTourisFile")]
        public async Task<ActionResult<PhotosViewModel>> AddCADTouristFile(IFormFile file, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await userManager.FindByNameAsync(Email);
            var role = await userManager.GetRolesAsync(user1);
            //return Ok(role);
            if (role.Contains("Commercant"))
            {
                var user = await commercantService.GetCommercantByEmail(Email);
                if (user.CADTouristTraansp != null)
                    return BadRequest(StatusCodes.Status409Conflict);

                if (user.CADTouristTraansp == null)
                {
                    var result = await photoservice.AddCADTouristFilesAsync(file);
                    if (result.Error != null)
                        return BadRequest(StatusCodes.Status404NotFound);

                    var photo = new Photo
                    {

                        Url = result.SecureUrl.AbsoluteUri,
                        PublicId = result.PublicId,
                        TypeFile = "Transport File",
                        //   IsMain = true,
                        UserId = user.Id,
                    };

                    user.CADTouristTraansp = photo.Url.ToString();
                    // user.Photos.Add(photo);
                    await userManager.UpdateAsync(user);
                    await photoservice.InsertPhoto(photo);
                }
            }

            return Ok("Tourist Transport File Added Successfully");

        }

        [HttpDelete("DeleteImage")]
        public async Task<ActionResult> DeleteImage(Guid photoId, string Email)
        {
            var user = await userManager.FindByNameAsync(Email);
            var Picture = await photoservice.FindPicById(photoId);

            var photolink = user.PhotoLink;
            if (user.PhotoLink != null)
            {
                var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                user.PhotoLink = null;
                await userManager.UpdateAsync(user);
                await photoservice.DeletePic(photoId);
            }

            return Ok("Image Deleted");
        }
        [HttpDelete("DeleteRNEFile")]
        public async Task<ActionResult> DeleteRNEFile(Guid photoId, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await userManager.FindByNameAsync(Email);
            var role = await userManager.GetRolesAsync(user1);
            if (role.Contains("Commercant"))
            {
                var user = await commercantService.GetCommercantByEmail(Email);
                var Picture = await photoservice.FindPicById(photoId);
                var RNEFile = user.RNECopy;
                if (user.RNECopy != null)
                {
                    var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                    if (result.Error != null)
                        return BadRequest(result.Error.Message);

                    user.RNECopy = null;
                    await userManager.UpdateAsync(user);
                    await photoservice.DeletePic(photoId);
                }
            }
            if (role.Contains("Host"))
            {
                var user = await hostService.GetHostByEmail(Email);
                var Picture = await photoservice.FindPicById(photoId);
                var RNEFile = user.RNECopy;
                if (user.RNECopy != null)
                {
                    var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                    if (result.Error != null)
                        return BadRequest(result.Error.Message);

                    user.RNECopy = null;
                    await userManager.UpdateAsync(user);
                    await photoservice.DeletePic(photoId);
                }
            }
            return Ok("RNE Deleted");
        }
        [HttpDelete("DeleteLicenceFile")]
        public async Task<ActionResult> DeleteLicenceFile(Guid photoId, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await userManager.FindByNameAsync(Email);
            var role = await userManager.GetRolesAsync(user1);
            if (role.Contains("Commercant"))
            {
                var user = await commercantService.GetCommercantByEmail(Email);
                var Picture = await photoservice.FindPicById(photoId);
                var LicenceCopy = user.LicenceCopy;
                if (user.LicenceCopy != null)
                {
                    var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                    if (result.Error != null)
                        return BadRequest(result.Error.Message);

                    user.LicenceCopy = null;
                    await userManager.UpdateAsync(user);
                    await photoservice.DeletePic(photoId);
                }
            }
            if (role.Contains("Host"))
            {
                var user = await hostService.GetHostByEmail(Email);
                var Picture = await photoservice.FindPicById(photoId);
                var LicenceCopy = user.LicenceCopy;
                if (user.LicenceCopy != null)
                {
                    var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                    if (result.Error != null)
                        return BadRequest(result.Error.Message);

                    user.LicenceCopy = null;
                    await userManager.UpdateAsync(user);
                    await photoservice.DeletePic(photoId);
                }
            }
            return Ok("RNE Deleted");
        }
        [HttpDelete("DeleteCADTransportFile")]
        public async Task<ActionResult> DeleteCADTransportFile(Guid photoId, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await userManager.FindByNameAsync(Email);
            var role = await userManager.GetRolesAsync(user1);
            if (role.Contains("Commercant"))
            {
                var user = await commercantService.GetCommercantByEmail(Email);
                var Picture = await photoservice.FindPicById(photoId);
                var CADTouristTraansp = user.CADTouristTraansp;
                if (user.CADTouristTraansp != null)
                {
                    var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                    if (result.Error != null)
                        return BadRequest(result.Error.Message);

                    user.CADTouristTraansp = null;
                    await userManager.UpdateAsync(user);
                    await photoservice.DeletePic(photoId);
                }
            }

            return Ok("CAD Deleted");
        }
        [HttpDelete("DeleteCINFile")]
        public async Task<ActionResult> DeleteCINFile(Guid photoId, string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user1 = await userManager.FindByNameAsync(Email);
            var role = await userManager.GetRolesAsync(user1);

            if (role.Contains("Host"))
            {
                var user = await hostService.GetHostByEmail(Email);
                var Picture = await photoservice.FindPicById(photoId);
                var CINCopy = user.CINCopy;
                if (user.CINCopy != null)
                {
                    var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                    if (result.Error != null)
                        return BadRequest(result.Error.Message);

                    user.CINCopy = null;
                    await userManager.UpdateAsync(user);
                    await photoservice.DeletePic(photoId);
                }
            }
            return Ok("CIN Deleted");
        }

        [HttpPost("AddExperienceComment")]
        public async Task<IActionResult> AddExperienceComment(CommentsViewModel model, Guid expId, string clientId)
        {
            if (ModelState.IsValid)
            {
                Comments experience = new Comments
                {
                    DatePost = DateTime.Now,
                    Id = clientId,
                    ExperienceId = expId,
                    Post = model.Post,

                };
                var result = await commentService.InsertComments(experience);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddLodgingComment")]
        public async Task<IActionResult> AddLodgingComment(CommentsViewModel model, Guid expId, string clientId)
        {
            if (ModelState.IsValid)
            {
                Comments experience = new Comments
                {
                    DatePost = DateTime.Now,
                    Id = clientId,
                    LodgingId = expId,
                    Post = model.Post,

                };
                var result = await commentService.InsertComments(experience);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddFoodComment")]
        public async Task<IActionResult> AddFoodComment(CommentsViewModel model, Guid expId, string clientId)
        {
            if (ModelState.IsValid)
            {
                Comments experience = new Comments
                {
                    DatePost = DateTime.Now,
                    Id = clientId,
                    FoodServId = expId,
                    Post = model.Post,

                };
                var result = await commentService.InsertComments(experience);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost("AddTransportComment")]
        public async Task<IActionResult> AddTransportComment(CommentsViewModel model, Guid expId, string clientId)
        {
            if (ModelState.IsValid)
            {
                Comments experience = new Comments
                {
                    DatePost = DateTime.Now,
                    Id = clientId,
                    TransportId = expId,
                    Post = model.Post,
                };
                var result = await commentService.InsertComments(experience);
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpGet("GetAllExperienceComments")]
        public async Task<IActionResult> GetAllExperienceComments(Guid expId)

        {
            var list = await commentService.GetExperienceComments(expId);
            return Ok(list);
        }
        [HttpGet("GetAllTransportComments")]
        public async Task<IActionResult> GetAllTransportComments(Guid expId)

        {
            var list = await commentService.GetTransportComments(expId);
            return Ok(list);
        }
        [HttpGet("GetAllLodgingComments")]
        public async Task<IActionResult> GetAllLodgingComments(Guid expId)

        {
            var list = await commentService.GetLodgingComments(expId);
            return Ok(list);
        }
        [HttpGet("GetAllFoodComments")]
        public async Task<IActionResult> GetAllFoodComments(Guid expId)

        {
            var list = await commentService.GetFoodComments(expId);
            return Ok(list);
        }
    }
}

