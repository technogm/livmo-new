using BagNgo.ViewModels.Implementation;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BagNgo.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "", methods: "*")]
    [Route("api/[Controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Users> UserManager;
        private readonly IUserService userService;
        private readonly ICommercantService commercantService;
        private readonly IHostService hostService;
        private readonly IClientservice clientService;
        private readonly IAdminService adminService;
        private readonly IExperienceService experienceService;
        private readonly ILodgingService lodgingService;
        private readonly IFoodService foodService;
        private readonly ITransportService transportService;
        private readonly SignInManager<Users> signInManager;
        private readonly ILogger<AdminController> logger;
        private readonly IHostRepository hosrrep;
        private readonly ApplicationDbContext _DBContext;

        IConfiguration configuration;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<Users> userManager,
            IUserService _UserService, ICommercantService _CommercantService, IHostService _hostService,
            IClientservice _clientService, IAdminService _adminService, ILogger<AdminController> _logger,
            IExperienceService _experienceService, ILodgingService _lodgingService , ITransportService _transportService , IFoodService _foodservice,
            SignInManager<Users> _signInManager, IConfiguration _configuration, IHostRepository _hostresp, ApplicationDbContext dbbb)
        {
            this.roleManager = roleManager;
            UserManager = userManager;
            userService = _UserService;
            commercantService = _CommercantService;
            hostService = _hostService;
            clientService = _clientService;
            adminService = _adminService;
            logger = _logger;
            signInManager = _signInManager;
            configuration = _configuration;
            hosrrep = _hostresp;
            _DBContext = dbbb;
            foodService = _foodservice;
            transportService = _transportService;
            experienceService = _experienceService;
            lodgingService = _lodgingService;
        }
        /// <summary>
        /// Login & Make admin :
        /// </summary>
        /// <returns></returns>

        [HttpPost("MakeAdmin")]
        public async Task<IActionResult> MakeAdmin(AdminViewModel model)
        {

            if (ModelState.IsValid)
            {

                var admin = new Admin
                {
                    UserName = model.Email,
                    Password = model.Password,
                    Email = model.Email,
                    ConfirmPassword = model.ConfirmPassword,
                    NomAdmin = model.NomAdmin,
                    PrenomAdmin = model.PrenomAdmin,
                    EmailConfirmed = true,


                };
                var result = await UserManager.CreateAsync(admin, model.Password);

                if (result.Succeeded)
                {
                    if (await roleManager.RoleExistsAsync("Administrateur"))
                    {
                        await UserManager.AddToRoleAsync(admin, "Administrateur");
                    }
                    else
                    {
                        IdentityRole identityrole = new IdentityRole
                        {
                            Name = "Admin"

                        };
                        await roleManager.CreateAsync(identityrole);
                        await UserManager.AddToRoleAsync(admin, "Administrateur");

                    }

                    return BadRequest("Error");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }
            return Ok("Admin created ssuccesfully");
        }

        /////////////// Roles Controllers ///////////

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var AllRoles = roleManager.Roles.ToList();
            return Ok(AllRoles);
        }


        [HttpPost("AddRole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                IdentityRole identityrole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityrole);
                if (result.Succeeded)
                {

                    return Ok("The role has been added successfully");
                }

            }
            return Ok();
        }
        [HttpPost("EditRole")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return Ok("Role have been changed successfully");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return Ok();
            }
        }
        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole(EditRoleViewModel model)
        {

            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                // ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return BadRequest("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return Ok("Role deleted");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Ok();

            }
        }

        /////////// Get All Users //////////////

        [HttpGet("GetAllAdmins")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllAdmins()

        {
            var list = adminService.GetAllAdmins().ToList();

            return Ok(list);
        }

        [HttpGet("GetAllClients")]
        // [Authorize(Roles = "Admin")]
        public IActionResult GetAllClients()

        {
            var list = clientService.GetAllClients().ToList();

            return Ok(list);
        }

        [HttpGet("GetAllHosts")]
        public IActionResult GetAllHosts()

        {
            var list = hostService.GetAllHosts().ToList();

            return Ok(list);
        }
        [HttpGet("GetAllValidationsHosts")]
        public IActionResult GetAllValidationsHosts()

        {
            var list = hostService.GetHostValidations().ToList();

            return Ok(list);
        }
        [HttpGet("GetAllHostEnAttente")]
        public IActionResult GetAllHostEnAttente()

        {
            var list = hostService.GetHostEnAttente().ToList();

            return Ok(list);
        }
        [HttpGet("GetAllIndividualHosts")]
        public IActionResult GetAllIndividualHosts()

        {
            var list = hostService.GetIndividualHosts().ToList();

            return Ok(list);
        }
        [HttpGet("GetAllOrganisationsHosts")]
        public IActionResult GetAllOrganisationsHosts()

        {
            var list = hostService.GetOragnaisationsHosts().ToList();

            return Ok(list);
        }

        [HttpGet("GetAllTransportCommercant")]
        public IActionResult GetAllTransportCommercant()

        {
            var list = commercantService.GetAllTransportComm().ToList();

            return Ok(list);
        }
        [HttpGet("GetAllRestaurantommercant")]
        public IActionResult GetAllRestaurantommercant()

        {
            var list = commercantService.GetAllFoodComm().ToList();

            return Ok(list);
        }
        [HttpGet("GetAllLodgingCommercants")]
        public IActionResult GetAllLodgingCommercants()

        {
            var list = commercantService.GetAllLodgingComm().ToList();

            return Ok(list);
        }
        [HttpGet("GetAllValidationsCommercant")]
        public IActionResult GetAllValidationsCommercant()

        {
            var list = commercantService.GetCommValidations().ToList();

            return Ok(list);
        }
        [HttpGet("GetAllCommercantEnAttente")]
        public IActionResult GetAllCommercantEnAttente()

        {
            var list = commercantService.GetCommEnAttente().ToList();

            return Ok(list);
        }

        [HttpGet("GetAllCommercants")]
        public IActionResult GetAllCommercants()

        {
            var list = commercantService.GetAllCommercants().ToList();

            return Ok(list);
        }

        [HttpGet("GetUserById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Users>> GetUserById(string id)
        {
            return await UserManager.FindByIdAsync(id);

        }
        [HttpGet("GetHostById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Users>> GetHostById(string id)
        {
            return await hostService.GetHostById(id);

        }
   
        [HttpGet("GetCommercantById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Users>> GetCommercantById(string id)
        {
            return await commercantService.GetCommercantById(id);
        }
        [HttpGet("GetClientById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Users>> GetClientById(string id)
        {
            return await clientService.GetClientById(id);
        }

        [HttpPost("HostSetValid/{email}")]
        public async Task<Boolean> HostSetValid( string email)
        {
            var com = await hostService.GetHostByEmail(email);
            com.Verified = "Valid";
            try
            {
                await hostService.PutHostAsync(com.Id,com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        [HttpPost("HostSetNonValid/{email}")]
        public async Task<Boolean> HostSetNonValid(string email)
        {
            var com = await hostService.GetHostByEmail(email);
            com.Verified = "InValid";
            try
            {
                await hostService.PutHostAsync(com.Id, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        [HttpPost("ComercantSetValid/{email}")]
        public async Task<Boolean> ComercantSetValid(string email)
        {
            var com = await commercantService.GetCommercantByEmail(email);
            com.Verified = "Valid";
            try
            {
                await commercantService.UpdateCommercantAsync(com.Id, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        [HttpPost("ComercantSetNonValid/{email}")]
        public async Task<Boolean> ComercantSetNonValid(string email)
        {
            var com = await commercantService.GetCommercantByEmail(email);
            com.Verified = "InValid";
            try
            {
                await commercantService.UpdateCommercantAsync(com.Id, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }


        //Experience : 


        [HttpPost("ExperienceSetValid/{id}")]
        public async Task<Boolean> ExperienceSetValid(Guid email)
        {
            var com = await experienceService.FindExperienceById(email);
            com.ExperienceStatus = "Valid";
            try
            {
                await experienceService.UpdateExperienceAsync(com.ExperienceId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        [HttpPost("ExperienceSetNonValid/{email}")]
        public async Task<Boolean> ExperienceSetNonValid(Guid email)
        {
            var com = await experienceService.FindExperienceById(email);
            com.ExperienceStatus = "InValid";
            try
            {
                await experienceService.UpdateExperienceAsync(com.ExperienceId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        //Lodging : 


        [HttpPost("LodgingSetValid/{id}")]
        public async Task<Boolean> LodgingSetValid(Guid email)
        {
            var com = await lodgingService.FindLodgingServiceById(email);
            com.Status = "Valid";
            try
            {
                await lodgingService.UpdateLodgingServiceAsync(com.LodgingId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        [HttpPost("LodgingSetNonValid/{email}")]
        public async Task<Boolean> LodgingSetNonValid(Guid email)
        {
            var com = await lodgingService.FindLodgingServiceById(email);
            com.Status = "InValid";
            try
            {
                await lodgingService.UpdateLodgingServiceAsync(com.LodgingId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
    
        //Food : 


        [HttpPost("FoodSetValid/{id}")]
        public async Task<Boolean> FoodSetValid(Guid email)
        {
            var com = await foodService.FindFoodServiceById(email);
            com.Status = "Valid";
            try
            {
                await foodService.UpdateFoodServiceAsync(com.FoodServId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        [HttpPost("FoodSetNonValid/{email}")]
        public async Task<Boolean> FoodSetNonValid(Guid email)
        {
            var com = await foodService.FindFoodServiceById(email);
            com.Status = "InValid";
            try
            {
                await foodService.UpdateFoodServiceAsync(com.FoodServId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        //Transport : 


        [HttpPost("TransportSetValid")]
        public async Task<Boolean> TransportSetValid(Guid id)
        {
            var com = await transportService.FindTransportServiceById(id);
            com.Status = "Valid";
            try
            {
                await transportService.UpdateTransportServiceAsync(com.TransportId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }
        [HttpPost("TransportSetNonValid/{email}")]
        public async Task<Boolean> TransportSetNonValid(Guid email)
        {

            var com = await transportService.FindTransportServiceById(email);
            com.Status = "InValid";
            try
            {
                await transportService.UpdateTransportServiceAsync(com.TransportId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        [HttpDelete("DeleteUserById/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                //ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return BadRequest("NotFound");
            }
            else
            {
                var result = await UserManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    //return StatusCode(200);
                    
                    this.HttpContext.Response.StatusCode = 200; 

                    return Json(new { status = "200" });

                }
                else
                
                    if (!result.Errors.Equals(0))
                        {
                        foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                    return StatusCode(402);

                }

                return Ok();

            }

        }

        [HttpGet("GetUserPhotoID")]
        public List<Guid> GetUserPhotoID(string Userid)
        {
            var list = userService.GetPhotoIdOfUser(Userid);
            return list;
        }
        [HttpGet("GetCINidOfUser")]
        public List<Guid> GetCINidOfUser(string Userid)
        {
            var list = userService.GetCINidOfUser(Userid);
            return list;
        }
        [HttpGet("GetCADTransportidOfUser")]
        public List<Guid> GetCADTransportidOfUser(string Userid)
        {
            var list = userService.GetCADTransportidOfUser(Userid);
            return list;
        }
        [HttpGet("GetRNEidOfUser")]
        public List<Guid> GetRNEidOfUser(string Userid)
        {
            var list = userService.GetRNEidOfUser(Userid);
            return list;
        }
        [HttpGet("GetLicenceidOfUser")]
        public List<Guid> GetLicenceidOfUser(string Userid)
        {
            var list = userService.GetLicenceidOfUser(Userid);
            return list;
        }
    }
}
