using BagNgo.ViewModels.Implementation;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BagNgo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService ExperienceService;
        private readonly ITransportExperienceServices TransportExpService;
        private readonly ILodgingExperienceService lodgingExperienceService;
        private readonly IFoodExperienceService foodExperienceService;
        private readonly IActivityServices activityServices;
        private readonly IExperiencesDatesServices experiencesDatesServices;
        private readonly SignInManager<Users> signInManager;
        private readonly IHostService hostService;
        private readonly UserManager<Users> userManager;
        private readonly IUserService userService;
        private readonly ApplicationDbContext _db;
        private readonly IPhotoService photoservice;
        private readonly IExperienceRepository exprep;
        private readonly ICommentService comment;



        public ExperienceController(ApplicationDbContext db,
            IExperienceRepository _exp,IPhotoService _phoroservice, ICommentService commentService, IUserService _UserService, IExperiencesDatesServices _experiencesDatesServices ,  IFoodExperienceService _foodExperienceService , IActivityServices _activityServices,ILodgingExperienceService _lodgingExperienceService,ITransportExperienceServices _tranExpServ ,IExperienceService _experienceService, UserManager<Users> _userManager, SignInManager<Users> _signInManager, IHostService _hostService)
        {
            _db = db;
            ExperienceService = _experienceService;
            userService = _UserService;
            userManager = _userManager;
            signInManager =_signInManager;
            hostService = _hostService;
            TransportExpService = _tranExpServ;
            lodgingExperienceService = _lodgingExperienceService;
            foodExperienceService = _foodExperienceService;
            activityServices = _activityServices;
            experiencesDatesServices = _experiencesDatesServices;
            photoservice = _phoroservice;
            comment = commentService;
            exprep = _exp;

        }
       
        // Experience controllers
        [HttpPost("CreateExperience")]
        public async Task<IActionResult> CreateExperience( ExperienceViewModel model , string id)
        {
            String ExpStatus = "En Attente";
            if (ModelState.IsValid)
            {
                Experience experience = new Experience
                {
                    ExperienceTitle = model.ExperienceTitle,
                    Location = model.Location,
                    Price = model.Price,
                    ExperienceStatus = ExpStatus,
                    MapLocation = model.MapLocation,
                    PriceUnit = model.PriceUnit,
                    Spots = model.Spots,
                    Theme = model.Theme,
                    SubTheme = model.SubTheme,
                    DatType = model.DatType,
                    DurationDays = model.DurationDays,
                    DurationHours = model.DurationHours,        
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    Season = model.Season,
                    ExperienceDescription = model.ExperienceDescription,
                    FoodExist = model.FoodExist,
                    LodgingExist = model.LodgingExist,
                    TransportExist = model.TransportExist,
                    PetsAllowed = model.PetsAllowed,
                    MinAge = model.MinAge,
                    OtherCritics = model.OtherCritics,
                    HostId = id,
                };
                var result = await ExperienceService.InsertExperience(experience);
                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPut("UpdateExperience")]
        public async Task<ActionResult<EditExperienceViewModel>> Editexperience(EditExperienceViewModel model, Guid id)
        {

            var experience = await ExperienceService.FindExperienceById(id);
            Console.WriteLine(" Experience : {0}", experience);
            if (experience == null)
            {
                return NotFound("experience not found");
            }
            else
            {

                experience.ExperienceTitle = model.Title;
                experience.Location = model.Location;
                experience.ExperienceStatus = model.ExperienceStatus;
                experience.Price = model.Price;
                experience.PriceUnit = model.PriceUnit;
                experience.MapLocation = model.MapLocation;
                experience.Spots = model.Spots;
                experience.Theme = model.Theme;
                experience.SubTheme = model.SubTheme;
                experience.DatType = model.DatType;
                experience.DurationDays = model.DurationDays;
                experience.DurationHours = model.DurationHours;
                experience.StartDate = model.StartDate;
                experience.EndDate = model.EndDate;
                experience.ExperienceDescription = model.Description;


            }
            await ExperienceService.UpdateExperienceAsync(id, experience);

            return new EditExperienceViewModel()
            {

                Title = model.Title,
                Location = model.Location,
                ExperienceStatus = model.ExperienceStatus,
                Price = model.Price,
                PriceUnit = model.PriceUnit,
                MapLocation = model.MapLocation,
                Spots = model.Spots,
                Theme = model.Theme,
                SubTheme = model.SubTheme,
                DatType = model.DatType,
                DurationDays = model.DurationDays,
                DurationHours = model.DurationHours,
                StartDate = model.StartDate,
                EndDate = model.EndDate,

            };
        }
        [HttpDelete("DeleteExperienceById/{id}")]
        public async Task<ActionResult> DeleteExperience(Guid id)
        {

            var exp = await ExperienceService.FindExperienceById(id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }

            else
            {
                try { 
                var exp1 = await comment.GetExperienceComments(exp.ExperienceId);
                foreach (var item in exp1.ToList())
                {
                    await comment.DeleteComments(item.CommentId);
                }
                    await ExperienceService.DeleteExperience(id);

                }
                catch (Exception e)
                {
                }


                return StatusCode(StatusCodes.Status200OK);

            }
        }
        [HttpGet("GetExperienceById/{id}")]
        public async Task<ActionResult<Experience>> GetExperienceById(Guid id)
        {
            return await ExperienceService.FindExperienceById(id);
        }
        [HttpGet("GetAllExperiences")]
        public IActionResult GetAllExperiences()

        {
            var list = ExperienceService.GetAllExperiences();

            return Ok(list);
        }
        [HttpGet("GetAllHostsExperiences/{id}")]
        public async Task <IActionResult> GetAllHostsExperiences(string id)

        {
            var list = await ExperienceService.GetAllHostExperiences(id);

            return Ok(list);
        }

        [HttpGet("GetAllValidExperiences")]
        public async Task<IActionResult> GetAllValidExperiences()

        {
            var list = await ExperienceService.GetValidExperiences();

            return Ok(list);
        }
        [HttpGet("GetAllLinksURL")]
        public List<string> GetListURL(Guid id)
        { 
            var list =  ExperienceService.GetAllExperienceImagesLink(id);
            return list;
        }
        [HttpGet("GetAllFoodExperienceLinksURL")]
        public List<string> getAllFoodLinksURL(Guid id)
        {
            var list = foodExperienceService.GetAllFoodExperienceImagesLink(id);
            return list;
        }
        [HttpGet("GetAllTransportExperienceLinksURL")]
        public List<string> getAllTransportLinksURL(Guid id)
        {
            var list = TransportExpService.GetAllTransportExperienceImagesLink(id);
            return list;
        }
        [HttpGet("GetAllLodgingExperienceLinksURL")]
        public List<string> getAllLodgingLinksURL(Guid id)
        {
            var list = lodgingExperienceService.GetAllLdogingExperienceImagesLink(id);
            return list;
        }
        [HttpGet("GetAllActivityLinksURL")]
        public List<string> getAllActivityLinksURL(Guid id)
        {
            var list = activityServices.GetAllActivityImagesLink(id);
            return list;
        }


        // All IDS :

        [HttpGet("GetAllFoodExperienceIDS")]
        public List<Guid> getAllFoodIDSURL(Guid id)
        {
            var list = foodExperienceService.getAllFoodExpIDS(id);
            return list;
        }
        [HttpGet("GetAllTransportExperienceIDS")]
        public List<Guid> getAllTransporIDSURL(Guid id)
        {
            var list = TransportExpService.getAllTransportExpIDS(id);
            return list;
        }
        [HttpGet("GetAllLodgingExperienceIDS")]
        public List<Guid> getAllLodgingIDSURL(Guid id)
        {
            var list = lodgingExperienceService.getAllLodgingExpIDS(id);
            return list;
        }
        [HttpGet("GetAllActivityIDS")]
        public List<Guid> getAllActivityIDSURL(Guid id)
        {
            var list = activityServices.getAllActitvityIDS(id);
            return list;
        }

        [HttpGet("GetAllExperiencePhotosIDS")]
        public List<Guid> GetAllExperiencePhotosIDS(Guid id)
        {
            var list = ExperienceService.getAllExperienceIDS(id);
            return list;
        }

        // Experience Status : 

        [HttpGet("GetHostValidExperiences")]
        public IActionResult GetHostValidExperiences(string Hostid)

        {
            var list = ExperienceService.GetHostValidExperiences(Hostid);

            return Ok(list);
        }
        [HttpGet("GetHostEnAttExperiences")]
        public IActionResult GetHostEnAttExperiences(string Hostid)

        {
            var list = ExperienceService.GetHostEnAttExperiences(Hostid);

            return Ok(list);
        }
        [HttpGet("GetHostInvalidExperiences")]
        public IActionResult GetHostInvalidExperiences(string Hostid)

        {
            var list = ExperienceService.GetHostInvalidExperiences(Hostid);

            return Ok(list);
        }


        // Experience Dates  : 

        [HttpPost("AddDatesForExperience")]
        public async Task<IActionResult> AddExperienceDates(ExperienceDatesViewModels model, Guid expId)
        {
            if (ModelState.IsValid)
            {
                ExperienceDates experience = new ExperienceDates
                {
                    StartTimeExpDate = model.StartTimeExpDate,
                    EndTimeExpDate = model.EndTimeExpDate,
                    ExperienceId = expId,
                   

                };
                var result = await experiencesDatesServices.InsertExperienceDates(experience);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpPost("GetAllDatesForSpecificExperience/{idExp}")]
        public IActionResult GetAllExperienceDates( Guid expId)
        {
            var list = experiencesDatesServices.GetExperienceDatess(expId);
            return Ok(list);
        }
        [HttpDelete("DeleteDatesExpById")]
        public async Task<ActionResult> DeleteDatesExpById(Guid Id)

        {
            var exp = await experiencesDatesServices.GetExperienceDatess(Id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await experiencesDatesServices.DeleteExperienceDates(Id);
                return StatusCode(StatusCodes.Status200OK);
            }
        }

        // Transport Services
        [HttpPost("AddTransport")]
        public async Task <IActionResult> AddTransportToExperience (TransportExperienceViewModel model, Guid expId)
        {
            if (ModelState.IsValid)
            {
                TransportExperience experience = new TransportExperience
                {
                   VehiculeName = model.VehiculeName,
                   Seats = model.Seats,
                   ToGoFrom = model.ToGoFrom,
                   ToGoTo = model.ToGoTo,
                   ToGoToArrival = model.ToGoToArrival,
                   ToGoFromDeparture = model.ToGoFromDeparture,
                   ToReturnFrom = model.ToReturnFrom,
                   ToReturnTo = model.ToReturnTo,
                   ToReturnFromDeparture = model.ToReturnFromDeparture,
                   ToReturnToArrival = model.ToReturnToArrival,
                   Description = model.Description,                 
                   ExperienceId = expId,

                };
                var result = await TransportExpService.InsertTransportExperience(experience);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
        
        [HttpGet("GetAllTransportExperiences")]
        public IActionResult GetAllTransportExperiences()

        {
            var list = TransportExpService.GetAllTransportsExperiences();

            return Ok(list);
        }
        [HttpGet("GetTransportForSpecificExperience")]
        public async Task<IActionResult> GetTransportForExperience(Guid ExpId)

        {
            var list = await TransportExpService.GetTransportExperiences(ExpId);

            return Ok(list);
        }

        [HttpDelete("DeleteTransportExpById")]
        public async Task<ActionResult> DeleteTransportExpById(Guid Transid)
        {

            var exp = await TransportExpService.FindTransportByExperience(Transid);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await TransportExpService.DeleteTransportExperience(Transid);
                return StatusCode(StatusCodes.Status200OK);

            }
        }

        // Lodging Services

        [HttpPost("AddLodging")]
        public async Task<IActionResult> AddLodging(LodgingExperienceViewModel model, Guid expId)
        {
            if (ModelState.IsValid)
            {
                LodgingExperience experience = new LodgingExperience
                {
                   Category = model.Category,
                   Type = model.Type,
                   Adress = model.Adress,
                   Description = model.Description,
                   Instructions = model.Instructions,
                   Criteria = model.Criteria,
                   StartDateLodgignExp = model.StartDateLodgignExp,
                   EndDateLodgingExp = model.EndDateLodgingExp,
                   ExperienceId = expId,

                };
                var result = await lodgingExperienceService.InsertLodgingExperience(experience);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpGet("GetAllLodgingExperiences")]
        public IActionResult GetAllLodgingExperiences()

        {
            var list = lodgingExperienceService.GetAllLodgingExperiences();

            return Ok(list);
        }
        [HttpGet("GetLodgingForSpecificExperience")]
        public async Task<IActionResult> GetLodgingForSpecificExperience(Guid ExpId)

        {
            var list = await lodgingExperienceService.GetLodgingExperiences(ExpId);

            return Ok(list);
        }
        [HttpDelete("DeleteLodgingExpById")]
        public async Task<ActionResult> DeleteLodgingExpById(Guid lodgid)
        {

            var exp = await lodgingExperienceService.FindLodgingByExperience(lodgid);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await lodgingExperienceService.DeleteLodgingExperience(lodgid);
                return StatusCode(StatusCodes.Status200OK);

            }
        }
        // Food Services
        [HttpPost("AddFood")]
        public async Task<IActionResult> AddFood(FoodExperienceViewModel model, Guid expId)
        {
            if (ModelState.IsValid)
            {
                FoodExperience experience = new FoodExperience
                {
                    NameDish = model.NameDish,
                    Description = model.Description,
                    ExperienceId = expId,

                };
                var result = await foodExperienceService.InsertFoodExperience(experience);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpGet("GetAllFoodExperiences")]
        public IActionResult GetAllFoodExperiences()

        {
            var list = foodExperienceService.GetAllFoodExperiences();

            return Ok(list);
        }
        [HttpGet("GetFoodForSpecificExperience")]
        public async Task<IActionResult> GetFoodForSpecificExperience(Guid ExpId)

        {
            var list = await foodExperienceService.GetFoodExperiences(ExpId);

            return Ok(list);
        }
        [HttpDelete("DeleteFoodExpById")]
        public async Task<ActionResult> DeleteFoodExpById(Guid foodid)
        {

            var exp = await foodExperienceService.FindFoodByExperience(foodid);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            
                await foodExperienceService.DeleteFoodExperience(foodid);
                return StatusCode(StatusCodes.Status200OK);
            }

        // Activity 
        [HttpPost("AddActivity")]
        public async Task<IActionResult> AddActivity(ActivityViewModel model, Guid expId)
        {
            if (ModelState.IsValid)
            {
                Activity experience = new Activity
                {
                    StartDateActivity = model.StartDateActivity,
                    EndDateActivity = model.EndDateActivity,
                    StartTimeActivity = model.StartTimeActivity,
                    EndTimeActivity = model.EndTimeActivity,
                    Description = model.Description,
                    Title = model.Title,
                    ExperienceId = expId,
                    
                };
                var result = await activityServices.InsertActivity(experience);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpGet("GetAlActivityExperiences")]
        public IActionResult GetAlActivityExperiences()

        {
            var list = activityServices.GetAllActivity();

            return Ok(list);
        }
        [HttpGet("GetActivityForSpecificExperience")]
        public async Task<IActionResult> GetActivityForSpecificExperience(Guid ExpId)

        {
            var list = await activityServices.GetActivitys(ExpId);

            return Ok(list);
        }

        [HttpDelete("DeleteActivityExpById")]
        public async Task<ActionResult> DeleteActivityExpById(Guid activId)
        {

            var exp = await activityServices.FindActivityByExperience(activId);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else

                await activityServices.DeleteActivity(activId);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost("AddPExphoto")]
        public async Task<ActionResult<PhotosViewModel>> AddPhoto(IFormFile file, Guid ExperienceID)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var experience = await ExperienceService.FindExperienceById(ExperienceID);
            //return Ok(experience.ExperienceId);
            if (experience.Photos == null || experience.Photos.Count == 0)
            {
                var result = await photoservice.InsertExperiencePhotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosExperience
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Experience Picture",
                    ExperienceIDFK = ExperienceID,
                };
                await photoservice.InsertExperiencePhoto(photo);


            }

            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddActPhoto")]
        public async Task<ActionResult<PhotosViewModel>> AddActPhoto(IFormFile file, Guid activityId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var activ = await activityServices.FindActivityById(activityId);
            //return Ok(experience.ExperienceId);
            if (activ.Activityphoto == null || activ.Activityphoto.Count == 0)
            {
                var result = await photoservice.InsertActivityPhotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosActivity
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Activity Picture",
                    ActivitiyId = activityId,
                };
                await photoservice.InsertActivityPhoto(photo);

            }

            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddLodgPhoto")]
        public async Task<ActionResult<PhotosViewModel>> AddLodgPhoto(IFormFile file, Guid activityId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var activ = await lodgingExperienceService.FindLodgingByExperience(activityId);
            if (activ.Lodgingphoto == null || activ.Lodgingphoto.Count == 0)
            {
                var result = await photoservice.InsertLodgingExperiencePhotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosLodgingsExp
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Lodging Experience Picture",
                    LodgingExperineceId = activityId,
                };
                await photoservice.InsertLodgingExpPhoto(photo);

                // experience.PhotoLink = photo.Url.ToString();
                // experience.Photos = photo;
                // await userManager.UpdateAsync(user);
                // await photoservice.InsertPhoto(photo);

            }

            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddTransPhoto")]
        public async Task<ActionResult<PhotosViewModel>> AddTransPhoto(IFormFile file, Guid activityId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var activ = await TransportExpService.FindTransportByExperience(activityId);
            //return Ok(experience.ExperienceId);
            if (activ.Transphoto == null || activ.Transphoto.Count == 0)
            {
                var result = await photoservice.InsertTransportExperiencePhotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosTransportsExp
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Transport Experience Picture",
                    TransportExperineceId = activityId,
                };
                await photoservice.InsertTransportExpPhoto(photo);

                // experience.PhotoLink = photo.Url.ToString();
                // experience.Photos = photo;
                // await userManager.UpdateAsync(user);
                // await photoservice.InsertPhoto(photo);

            }

            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddFoodPhoto")]
        public async Task<ActionResult<PhotosViewModel>> AddFoodPhoto(IFormFile file, Guid activityId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var activ = await foodExperienceService.FindFoodByExperience(activityId);
            //return Ok(experience.ExperienceId);
            if (activ.Foodphoto == null || activ.Foodphoto.Count == 0)
            {
                var result = await photoservice.InsertFoodExperiencePhotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosFoodExp
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Food Experience Picture",
                    FoodxperineceId = activityId,
                };
                await photoservice.InsertFoodExpPicPhoto(photo);

                // experience.PhotoLink = photo.Url.ToString();
                // experience.Photos = photo;
                // await userManager.UpdateAsync(user);
                // await photoservice.InsertPhoto(photo);

            }

            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpDelete("deleteExpPhoto")]
        public async Task<ActionResult<PhotosViewModel>> deletePhoto(Guid photoId)
        {
           
                var Picture = await photoservice.FindExperiencePicById(photoId);

                if (Picture.Id== photoId)
                {
                    var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                    if (result.Error != null)
                        return BadRequest(result.Error.Message);

                    await photoservice.DeleteExperiencePic(photoId);
                }

                return Ok("Image Deleted");
       
        }
        [HttpDelete("deleteActPhoto")]
        public async Task<ActionResult<PhotosViewModel>> deleteActPhoto(Guid photoId)
        {

            var Picture = await photoservice.FindActivityPicById(photoId);

            if (Picture.Id == photoId)
            {
                var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                await photoservice.DeleteActivityPic(photoId);
            }

            return Ok("Image Deleted");

        }
        [HttpDelete("deleteLdogPhoto")]
        public async Task<ActionResult<PhotosViewModel>> deleteLodgPhoto(Guid photoId)
        {

            var Picture = await photoservice.FindLodgingExpPicById(photoId);

            if (Picture.Id == photoId)
            {
                var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                await photoservice.DeleteLodgingExpPic(photoId);
            }

            return Ok("Image Deleted");

        }
        [HttpDelete("deleteLTransPhoto")]
        public async Task<ActionResult<PhotosViewModel>> deleteTransPhoto(Guid photoId)
        {

            var Picture = await photoservice.FindTransportExpPicById(photoId);

            if (Picture.Id == photoId)
            {
                var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                await photoservice.DeleteTransportExpPic(photoId);
            }

            return Ok("Image Deleted");

        }
        [HttpDelete("deleteLFoodPhoto")]
        public async Task<ActionResult<PhotosViewModel>> deleteFoodPhoto(Guid photoId)
        {

            var Picture = await photoservice.FindFoodExpPicById(photoId);

            if (Picture.Id == photoId)
            {
                var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                await photoservice.DeleteFoodExpPicPic(photoId);
            }

            return Ok("Image Deleted");

        }


    }
}

