using BagNgo.ViewModels.Implementation;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagNgo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ServicesController : Controller
    {
        private readonly ILodgingService lodgingService;
        private readonly ITransportService transportService;
        private readonly IFoodService foodService;
        private readonly IPhotoService photoservice;

        public ServicesController(ILodgingService _lodgingservice , ITransportService _transportService , IFoodService _foodService , IPhotoService _photoService)
        {

            lodgingService = _lodgingservice;
            transportService = _transportService;
            foodService = _foodService;
            photoservice = _photoService; 
        }
        [HttpPost("CreateLodging")]
        public async Task<IActionResult> CreateLodging(string id, LodgingServiceViewModel model)
        {
            string stat = "En Attente";
            if (ModelState.IsValid)
            {
                LodgingService lodging = new LodgingService
                {
                    Status = stat,
                    LodgingAdress = model.LodgingAdress,
                    CommercantId = id,
                    LodgingCategory = model.LodgingCategory,
                    LodgingDescript = model.LodgingDescript,
                    LodgingName = model.LodgingName,
                    LodgingType = model.LodgingType,
                    LodgingWebsite = model.LodgingWebsite,
                    PricePerNight =model.PricePerNight,

                };
                var result = await lodgingService.InsertLodgingService(lodging);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("CreateTransport")]
        public async Task<IActionResult> CreateTransport(TransportServiceViewModel model, string id)
        {
            string stat = "En Attente";
            if (ModelState.IsValid)
            {
                TransportService transport = new TransportService
                {
                  CommercantId = id,
                  Gouvernorate = model.Gouvernorate,
                  Status = stat,
                  PricePerDay = model.PricePerDay,
                  NumberOfSeatd = model.NumberOfSeatd,
                  VehiculeRules = model.VehiculeRules,
                  VehuculeName = model.VehuculeName,
                  Activity = model.Activity,
                  Type = model.Type,
                  
                };
                var result = await transportService.InsertTransportService(transport);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("CreateFood")]
        public async Task<IActionResult> CreateFood(FoodServiceViewModel model, string id)
        {
            string stat = "En Attente";

            if (ModelState.IsValid)
            {
                FoodService food = new FoodService
                {
                    Adress = model.Adress,
                    ClosingHour = model.ClosingHour,
                    CommercantId = id,
                    DishDescription = model.DishDescription,
                    DishName = model.DishName,
                    FoodPrice = model.FoodPrice,
                    Status = stat,
                    OpenHour = model.OpenHour,
                    RestaurantName = model.RestaurantName,
                    Rules = model.Rules,
                    Slogan = model.Slogan,
                    Stars = model.Stars,
                    Website = model.Website,
                    RestaurantRules = model.RestaurantRules,
                    DaysOff = model.DaysOff,
                };
                var result = await foodService.InsertFoodService(food);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }
       
        // Transport 
        [HttpDelete("DeleteTransportById")]
        public async Task<ActionResult> DeleteTransport(Guid id)
        {

            var exp = await transportService.FindTransportServiceById(id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await transportService.DeleteTransportService(id);

                return StatusCode(StatusCodes.Status200OK);

            }
        }
        [HttpGet("GetTransportById/{id}")]
        public async Task<ActionResult<TransportService>> GetTransportByID(Guid id)
        {
            return await transportService.FindTransportServiceById(id);
        }
        [HttpGet("GetAllTransports")]
        public IActionResult GetAllTransports()

        {
            var list = transportService.GetAllTransportServices();

            return Ok(list);
        }
        [HttpGet("GetAllValidTransports")]
        public  async Task<IActionResult> GetAllValidTransports()

        {
            var list = await transportService.GetAllValidTransport();

            return Ok(list);
        }
        [HttpGet("GetAllCommercantTransport/{id}")]
        public async Task<IActionResult> GetAllCommercantTransport(string id)

        {
            var list = await transportService.GetAllCommercantTransportServices(id);

            return Ok(list);
        }
        [HttpGet("GetCommercantValidTransports")]
        public async Task<IActionResult> GetCommercantValidTransports(string id)

        {
            var list = await transportService.GetCommercantValidTransport(id);

            return Ok(list);
        }
        [HttpGet("GetCommercantInValidTransports")]
        public async Task<IActionResult> GetCommercantInValidTransports(string id)

        {
            var list = await transportService.GetCommercantInValidTransport(id);

            return Ok(list);
        }
        [HttpGet("GetCommercanEnAttenteTransports")]
        public async Task<IActionResult> GetCommercanEnAttenteTransports(string id)

        {
            var list = await transportService.GetCommercanEnAttenteTransport(id);

            return Ok(list);
        }
        [HttpGet("GetAllTransportLinksURL")]
        public List<string> GetAllTransportLinksURL(Guid id)
        {
            var list = transportService.GetAllTransServiceImagesLink(id);
            return list;
        }
     
        // Lodging 
        [HttpDelete("DeleteLodgingById/{id}")]
        public async Task<ActionResult> DeleteLodging(Guid id)
        {

            var exp = await lodgingService.FindLodgingServiceById(id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await lodgingService.DeleteLodgingService(id);

                return StatusCode(StatusCodes.Status200OK);

            }
        }
        [HttpGet("GetLodgingById/{id}")]
        public async Task<ActionResult<LodgingService>> GetLodgingByID(Guid id)
        {
            return await lodgingService.FindLodgingServiceById(id);
        }
        [HttpGet("GetAllLodging")]
        public IActionResult GetAllLodging()

        {
            var list = lodgingService.GetAllLodgingServices();

            return Ok(list);
        }
        [HttpGet("GetAllValidLodging")]
        public async Task<IActionResult> GetAllValidLodging()

        {
            var list = await lodgingService.GetAllValidLodging();

            return Ok(list);
        }
        [HttpGet("GetAllCommercantLodgings/{id}")]
        public async Task<IActionResult> GetAllCommercantLodgings(string id)

        {
            var list = await lodgingService.GetAllCommercantLodgingServices(id);

            return Ok(list);
        }
        [HttpGet("GetCommercantValidLodgings")]
        public async Task<IActionResult> GetCommercantValidLodgings(string id)

        {
            var list = await lodgingService.GetCommercantValidLodging(id);

            return Ok(list);
        }
        [HttpGet("GetCommercantInValidLodgings")]
        public async Task<IActionResult> GetCommercantInValidLodgings(string id)

        {
            var list = await lodgingService.GetCommercantInValidLodging(id);

            return Ok(list);
        }
        [HttpGet("GetCommercanEnAttenteLodgings")]
        public async Task<IActionResult> GetCommercanEnAttenteLodgings(string id)

        {
            var list = await lodgingService.GetCommercanEnAttenteLodging(id);

            return Ok(list);
        }
        [HttpGet("GetAllLodgingLinksURL")]
        public List<string> getAllLodgingLinksURL(Guid id)
        {
            var list = lodgingService.GetAllLodgingServiceImagesLink(id);
            return list;
        }

        // Food 
        [HttpDelete("DeleteFoodById/{id}")]
        public async Task<ActionResult> DeleteFood(Guid id)
        {

            var exp = await foodService.FindFoodServiceById(id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await foodService.DeleteFoodService(id);

                return StatusCode(StatusCodes.Status200OK);

            }
        }

        [HttpGet("GetFoodById/{id}")]
        public async Task<ActionResult<FoodService>> GetFoodByID(Guid id)
        {
            return await foodService.FindFoodServiceById(id);
        }
        [HttpGet("GetAllFood")]
        public IActionResult GetAllFood()

        {
            var list = foodService.GetAllFoodServices();

            return Ok(list);
        }
        [HttpGet("GetAllValidFood")]
        public async Task<IActionResult> GetAllValidFood()

        {
            var list =await foodService.GetAllValidFood();

            return Ok(list);
        }
        [HttpGet("GetAllCommercantFoods/{id}")]
        public async Task<IActionResult> GetAllCommercantFood(string id)

        {
            var list = await foodService.GetAllCommercantFoodServices(id);

            return Ok(list);
        }
        [HttpGet("GetCommercantValidFoods")]
        public async Task<IActionResult> GetCommercantValidFoods(string id)

        {
            var list = await foodService.GetCommercantValidFood(id);

            return Ok(list);
        }
        [HttpGet("GetCommercantInValidFoods")]
        public async Task<IActionResult> GetCommercantInValidFoods(string id)

        {
            var list = await foodService.GetCommercantInValidFood(id);

            return Ok(list);
        }
        [HttpGet("GetCommercanEnAttenteFoods")]
        public async Task<IActionResult> GetCommercanEnAttenteFoods(string id)

        {
            var list = await foodService.GetCommercanEnAttenteFood(id);

            return Ok(list);
        }
        [HttpGet("GetAllFoodLinksURL")]
        public List<string> GetAllFoodLinksURL(Guid id)
        {
            var list = foodService.GetAllFoodServiceImagesLink(id);
            return list;
        }


        // Photos : 

        [HttpPost("AddLodgingphoto")]
        public async Task<ActionResult<PhotosViewModel>> AddLodgingPhoto(IFormFile file, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var experience = await lodgingService.FindLodgingServiceById(id);
            //return Ok(experience.ExperienceId);
            if (experience.Lodgingphoto == null || experience.Lodgingphoto.Count == 0)
            {
                var result = await photoservice.InsertLodgingPhotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosLodgings
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Lodging Picture",
                    LodgingId = id,
                };
                await photoservice.InsertLodgingPhoto(photo);

              

            }

            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddRestaurantsphoto")]
        public async Task<ActionResult<PhotosViewModel>> AddRestaurantsphoto(IFormFile file, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var experience = await foodService.FindFoodServiceById(id);
            //return Ok(experience.ExperienceId);
            if (experience.RestaurantPhotos == null || experience.RestaurantPhotos.Count == 0)
            {
                var result = await photoservice.InsertRestaurantshotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosRestaurants
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Restaurant Picture",
                    FoodServId = id,
                };
                await photoservice.InsertRestaurantPhoto(photo);


            }

            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddFoodphoto")]
        public async Task<ActionResult<PhotosViewModel>> AddFoodPhoto(IFormFile file, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var experience = await foodService.FindFoodServiceById(id);
            //return Ok(experience.ExperienceId);
            if (experience.Foodhoto == null || experience.Foodhoto.Count == 0)
            {
                var result = await photoservice.InsertFoodPhotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosFood
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Food Picture",
                   FoodServId = id,
                };
                await photoservice.InsertFoodPhoto(photo);

                

            }

            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpPost("AddTransportphoto")]
        public async Task<ActionResult<PhotosViewModel>> AddTransportphoto(IFormFile file, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var experience = await transportService.FindTransportServiceById(id);
            //return Ok(experience.ExperienceId);
            if (experience.Transportphoto == null || experience.Transportphoto.Count == 0)
            {
                var result = await photoservice.InsertTransportPhotos(file);
                if (result.Error != null)
                    return BadRequest(StatusCodes.Status404NotFound);

                var photo = new PhotosTransports
                {

                    Url = result.SecureUrl.AbsoluteUri,
                    PublicId = result.PublicId,
                    IsMain = false,
                    TypeFile = "Transport Picture",
                    TransportId = id,
                };
                await photoservice.InsertTransportPhoto(photo);
            }
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("GetAllFoodIDS")]
        public List<Guid> getAllFoodIDSURL(Guid id)
        {
            var list = foodService.getAllFoodIDS(id);
            return list;
        }
        [HttpGet("GetAllTransportIDS")]
        public List<Guid> getAllTransporIDSURL(Guid id)
        {
            var list = transportService.getAllTransportIDS(id);
            return list;
        }
        [HttpGet("GetAllLodgingIDS")]
        public List<Guid> getAllLodgingIDSURL(Guid id)
        {
            var list = lodgingService.getAllLodgingIDS(id);
            return list;
        }
        [HttpDelete("deleteLodgingPhoto")]
        public async Task<ActionResult<PhotosViewModel>> deleteLodgingPhoto(Guid photoId)
        {

            var Picture = await photoservice.FindLodgingPicById(photoId);

            if (Picture.Id == photoId)
            {
                var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                await photoservice.DeleteLodgingPic(photoId);
            }

            return Ok("Image Deleted");

        }
        [HttpDelete("deleteTransportPhoto")]
        public async Task<ActionResult<PhotosViewModel>> deleteTransPhoto(Guid photoId)
        {

            var Picture = await photoservice.FindTransportPicById(photoId);

            if (Picture.Id == photoId)
            {
                var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                await photoservice.DeleteTransportPic(photoId);
            }

            return Ok("Image Deleted");

        }

        [HttpDelete("deleteFoodPhoto")]
        public async Task<ActionResult<PhotosViewModel>> deleteFoodPhoto(Guid photoId)
        {

            var Picture = await photoservice.FindFoodPicById(photoId);

            if (Picture.Id == photoId)
            {
                var result = await photoservice.DeletePhotoAsync(Picture.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                await photoservice.DeleteFoodPic(photoId);
            }

            return Ok("Image Deleted");

        }
    }
}
