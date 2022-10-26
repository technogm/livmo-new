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
    public class ReservationController : Controller
    {
        private readonly IReservationTransportService transportReservationService;

        private readonly IReservationFoodService FoodReservationService;

        private readonly IReservationLodgingService LodgingReservationService;
        private readonly IReservationExperienceService ReservationExperienceService;

        private readonly ITransportService transportService;
        private readonly IFoodService foodService;
        private readonly ILodgingService lodgingService;

        public ReservationController(
              ITransportService _transportService, IReservationTransportService _transportReservation, IReservationExperienceService _experienceReservation
              , IFoodService _foodService, IReservationFoodService _foodReservation
              , ILodgingService _lodgingService, IReservationLodgingService _lodgingReservation)
        {
            transportReservationService = _transportReservation;
            transportService = _transportService;
            ReservationExperienceService = _experienceReservation;
            FoodReservationService = _foodReservation;
            foodService = _foodService;
            LodgingReservationService = _lodgingReservation;
            lodgingService = _lodgingService;
        }

        [HttpPost("CreateExperienceReservation")]
        public async Task<IActionResult> CreateexperienceReservation(ExperienceReservationViewModel model, string idClient, Guid idexperience)
        {

            if (ModelState.IsValid)
            {
                ExperiencesReservation exp = new ExperiencesReservation
                {

                    ClientId = idClient,
                    Status = "Pending",
                    ExperienceId = idexperience,
                    Price = model.Price,
                    EndDate = model.StartDate,
                    IntervalTime = model.IntervalTime,
                    StartDate = model.StartDate,
                    Seats = model.Seats,

                };
                var result = await ReservationExperienceService.InsertExperiencesReservation(exp);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpGet("GetExperienceReservationById/{id}")]
        public async Task<ActionResult<ExperiencesReservation>> GetExperienceReservationById(Guid id)
        {
            return await ReservationExperienceService.FindExperiencesReservationById(id);
        }



        [HttpDelete("DeleteExperienceReservationById/{id}")]
        public async Task<ActionResult> DeleteExperience(Guid id)
        {

            var exp = await ReservationExperienceService.FindExperiencesReservationById(id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await ReservationExperienceService.DeleteExperiencesReservation(id);

                return StatusCode(StatusCodes.Status200OK);

            }
        }

        [HttpPost("CreateTransportReservation")]
        public async Task<IActionResult> CreateTransportReservation(TransportReservationViewModel model, string idClient, Guid idTransportService)
        {
            if (ModelState.IsValid)
            {
                TransportReservation transport = new TransportReservation
                {

                    ClientId = idClient,
                    Status = "Pending",
                    PriceTransport = model.PriceTransport,
                    StartDateReservation = model.StartDateReservation,
                    EndDateReservation = model.EndDateReservation,   
                    TransportId = idTransportService,
                };
                var result = await transportReservationService.InsertTransportReservation(transport);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpGet("GetTransportRById/{id}")]
        public async Task<ActionResult<TransportReservation>> GetTransportRByID(Guid id)
        {
            return await transportReservationService.FindTransportReservationById(id);
        }



        [HttpDelete("DeleteTransportReservationById/{id}")]
        public async Task<ActionResult> DeleteTransport(Guid id)
        {

            var exp = await transportReservationService.FindTransportReservationById(id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await transportReservationService.DeleteTransportReservation(id);

                return StatusCode(StatusCodes.Status200OK);

            }
        }

        [HttpPost("CreateLodgingReservation")]
        public async Task<IActionResult> CreateLodgingReservation(LodgingReservationViewModel model, string idClient, Guid idLodgingService)
        {
            if (ModelState.IsValid)
            {
                LodgingReservation lodging = new LodgingReservation
                {

                    ClientId = idClient,
                    Status = "Pending",
                   Seats = model.Seats,
                   PriceLodging = model.PriceLodging,
                   ReservationLArrival = model.ReservationLArrival,
                   ReservationLDeparture = model.ReservationLDeparture,
                    LodgingId = idLodgingService,
                };
                var result = await LodgingReservationService.InsertLodgingReservation(lodging);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpGet("GetLodgingReservationById/{id}")]
        public async Task<ActionResult<LodgingReservation>> GetLodgingByID(Guid id)
        {
            return await LodgingReservationService.FindLodgingReservationById(id);
        }



        [HttpDelete("DeleteLodgingReservationById/{id}")]
        public async Task<ActionResult> DeleteLodging(Guid id)
        {

            var exp = await LodgingReservationService.FindLodgingReservationById(id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await LodgingReservationService.DeleteLodgingReservation(id);

                return StatusCode(StatusCodes.Status200OK);

            }
        }

        [HttpPost("CreateFoodReservation")]
        public async Task<IActionResult> CreateFoodReservation(FoodReservationViewModel model, string idClient, Guid idFoodService)
        {
            if (ModelState.IsValid)
            {
                FoodReservation lodging = new FoodReservation
                {

                    ClientId = idClient,
                    Status = "Pending",
                    Arrival = model.Arrival,
                    PriceFood = model.PriceFood,
                    Seats = model.Seats,                  
                    FoodServId = idFoodService,
                };
                var result = await FoodReservationService.InsertFoodReservation(lodging);

                return Ok(result);

            }
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpGet("GetFoodRById/{id}")]
        public async Task<ActionResult<FoodReservation>> GetFoodByID(Guid id)
        {
            return await FoodReservationService.FindFoodReservationById(id);
        }
        [HttpDelete("DeleteFoodReservationById/{id}")]
        public async Task<ActionResult> DeleteFood(Guid id)
        {

            var exp = await FoodReservationService.FindFoodReservationById(id);

            if (exp == null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                await FoodReservationService.DeleteFoodReservation(id);

                return StatusCode(StatusCodes.Status200OK);

            }
        }
        
        [HttpGet("GetAllTransportReservation")]
        public IActionResult GetAll()

        {
            var list = transportReservationService.GetAllTransportReservation();

            return Ok(list);
        }
        [HttpGet("GetAllAcceptedTransportReservation")]
        public IActionResult GetAllValidationsHosts()

        {
            var list = transportReservationService.GetTransportReservationAccepted();

            return Ok(list);
        }
        [HttpGet("GetAllDeclinedTransportReservation")]
        public IActionResult GetAllDeclinedTransportReservation()

        {
            var list = transportReservationService.GetTransportReservationRejected();

            return Ok(list);
        }
        [HttpGet("GetAllPaidTransportReservation")]
        public IActionResult GetAllPaidTransportReservation()

        {
            var list = transportReservationService.GetTransportReservationPaid();

            return Ok(list);
        }
        [HttpGet("GetAllPendingTransportReservation")]
        public IActionResult GetAllPendingTransportReservation()

        {
            var list = transportReservationService.GetTransportReservationPending();

            return Ok(list);
        }
        [HttpPost("REJECTtransportReservation/{id}")]
        public async Task<Boolean> RejectTransportReservation(Guid id)
        {
            var com = await transportReservationService.FindTransportReservationById(id);
            com.Status = "Invalid";
            try
            {
                await transportReservationService.UpdateStatus(com.TransportReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("AcceptTransportReservation/{id}")]
        public async Task<Boolean> AcceptTransportReservation(Guid id)
        {
            var com = await transportReservationService.FindTransportReservationById(id);
            com.Status = "Valid";
            try
            {
                await transportReservationService.UpdateStatus(com.TransportReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("ConfirmPaiementTransportReservation/{id}")]
        public async Task<Boolean> ConfirmPaiement(Guid id)
        {
            var com = await transportReservationService.FindTransportReservationById(id);
            com.Status = "Paid";
            try
            {
                await transportReservationService.UpdateStatus(com.TransportReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet("GetAllLodgingReservation")]
        public IActionResult GetAllLodging()

        {
            var list = LodgingReservationService.GetAllLodgingReservation();

            return Ok(list);
        }
        [HttpGet("GetAllAcceptedLodgingReservation")]
        public IActionResult GetAllValidationsLodging()

        {
            var list = LodgingReservationService.GetLodgingReservationAccepted();

            return Ok(list);
        }
        [HttpGet("GetAllDeclinedLodgingReservation")]
        public IActionResult GetAllDeclinedLodgingReservation()

        {
            var list = LodgingReservationService.GetLodgingReservationRejected();

            return Ok(list);
        }
        [HttpGet("GetAllPaidLodgingReservation")]
        public IActionResult GetAllPaidLodgingReservation()

        {
            var list = LodgingReservationService.GetLodgingReservationPaid();

            return Ok(list);
        }
        [HttpGet("GetAllPendingLodgingReservation")]
        public IActionResult GetAllPendingLodgingReservation()

        {
            var list = LodgingReservationService.GetLodgingReservationPending();

            return Ok(list);
        }
        
        [HttpPost("REJECTLodgingReservation/{id}")]
        public async Task<Boolean> RejectLodgingReservation(Guid id)
        {
            var com = await LodgingReservationService.FindLodgingReservationById(id);
            com.Status = "Invalid";
            try
            {
                await LodgingReservationService.UpdateStatus(com.LodgingReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("AcceptLodgingReservation/{id}")]
        public async Task<Boolean> AcceptLodgingReservation(Guid id)
        {
            var com = await LodgingReservationService.FindLodgingReservationById(id);
            com.Status = "Valid";
            try
            {
                await LodgingReservationService.UpdateStatus(com.LodgingReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("ConfirmPaiementLodgingReservation/{id}")]
        public async Task<Boolean> ConfirmPaiementOfLodging(Guid id)
        {
            var com = await LodgingReservationService.FindLodgingReservationById(id);
            com.Status = "Paid";
            try
            {
                await LodgingReservationService.UpdateStatus(com.LodgingReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }

        [HttpGet("GetAllFoodReservation")]
        public IActionResult GetAllFood()

        {
            var list = FoodReservationService.GetAllFoodReservation();

            return Ok(list);
        }
        [HttpGet("GetAllAcceptedFoodReservation")]
        public IActionResult GetAllValidationsFood()

        {
            var list = FoodReservationService.GetFoodReservationAccepted();

            return Ok(list.Result);
        }
        [HttpGet("GetAllDeclinedFoodReservation")]
        public IActionResult GetAllDeclinedFoodReservation()

        {
            var list = FoodReservationService.GetFoodReservationRejected();

            return Ok(list.Result);
        }
        [HttpGet("GetAllPaidFoodReservation")]
        public IActionResult GetAllPaidFoodReservation()

        {
            var list = FoodReservationService.GetFoodReservationPaid();

            return Ok(list.Result);
        }
        [HttpGet("GetAllPendingFoodReservation")]
        public IActionResult GetAllPendingFoodReservation()

        {
            var list = FoodReservationService.GetFoodReservationPending();

            return Ok(list.Result);
        }
       
        [HttpPost("REJECFoodReservation/{id}")]
        public async Task<Boolean> RejectFoodReservation(Guid id)
        {
            var com = await FoodReservationService.FindFoodReservationById(id);
            com.Status = "Invalid";
            try
            {
                await FoodReservationService.UpdateStatus(com.FoodReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("AcceptFoodReservation/{id}")]
        public async Task<Boolean> AcceptFoodReservation(Guid id)
        {
            var com = await FoodReservationService.FindFoodReservationById(id);
            com.Status = "Valid";
            try
            {
                await FoodReservationService.UpdateStatus(com.FoodReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("ConfirmPaiementFoodReservation/{id}")]
        public async Task<Boolean> ConfirmPaiementOfFood(Guid id)
        {
            var com = await FoodReservationService.FindFoodReservationById(id);
            com.Status = "Paid";
            try
            {
                await FoodReservationService.UpdateStatus(com.FoodReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }



        }








        [HttpGet("GetAllExperienceReservation")]
        public IActionResult GetAllExperience()

        {
            var list = ReservationExperienceService.GetAllExperiencesReservation();

            return Ok(list.Result);
        }
        [HttpGet("GetAllAcceptedExperienceReservation")]
        public IActionResult GetAllValidationsExperience()

        {
            var list = ReservationExperienceService.GetExperiencesReservationAccepted();

            return Ok(list.Result);
        }
        [HttpGet("GetAllDeclinedExperienceReservation")]
        public IActionResult GetAllDeclinedExperienceReservation()

        {
            var list = ReservationExperienceService.GetExperiencesReservationRejected();

            return Ok(list.Result);
        }
        [HttpGet("GetAllPaidExperienceReservation")]
        public IActionResult GetAllPaidExperienceReservation()

        {
            var list = ReservationExperienceService.GetExperiencesReservationPaid();

            return Ok(list.Result);
        }
        [HttpGet("GetAllPendingExperienceReservation")]
        public IActionResult GetAllPendingExperienceReservation()

        {
            var list = ReservationExperienceService.GetExperiencesReservationPending();

            return Ok(list.Result);
        }

        [HttpPost("REJECTExperienceReservation/{id}")]
        public async Task<Boolean> RejectExperienceReservation(Guid id)
        {
            var com = await ReservationExperienceService.FindExperiencesReservationById(id);
            com.Status = "Invalid";
            try
            {
                await ReservationExperienceService.UpdateStatus(com.ExperienceReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("AcceptExperienceReservation/{id}")]
        public async Task<Boolean> AcceptExperienceReservation(Guid id)
        {
            var com = await ReservationExperienceService.FindExperiencesReservationById(id);
            com.Status = "Valid";
            try
            {
                await ReservationExperienceService.UpdateStatus(com.ExperienceReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("ConfirmPaiementExperienceReservation/{id}")]
        public async Task<Boolean> ConfirmPaiementOfExperience(Guid id)
        {
            var com = await ReservationExperienceService.FindExperiencesReservationById(id);
            com.Status = "Paid";
            try
            {
                await ReservationExperienceService.UpdateStatus(com.ExperienceReservationId, com);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [HttpGet("GetClientTransportReservation")]
        public IActionResult GetClientTransportReservation(string id)

        {
            var list = transportReservationService.GetAllClientsTransportReservation(id);

            return Ok(list.Result);
        }
        [HttpGet("GetClientFoodReservation")]
        public IActionResult GetClientFoodReservation(string id)

        {
            var list = FoodReservationService.GetAllClientsFoodReservation(id);

            return Ok(list.Result);
        }
        [HttpGet("GetClientLodgingReservation")]
        public IActionResult GetClientLodgingReservation(string id)

        {
            var list = LodgingReservationService.GetAllClientsLodgingReservation(id);

            return Ok(list.Result);
        }
        [HttpGet("GetClientExperienceReservation")]
        public IActionResult GetClientExperienceReservation(string id)

        {
            var list = ReservationExperienceService.GetAllClientsExperiencesReservation(id);

            return Ok(list.Result);
        }


        [HttpGet("GetCommercantTransportReservation")]
        public IActionResult GetCommercantTransportReservation(string id)

        {
            var list = transportReservationService.GetAllCommercantTransportReservation(id);

            return Ok(list.Result);
        }
        [HttpGet("GetCommercantFoodReservation")]
        public IActionResult GetCommercantFoodReservation(string id)

        {
            var list = FoodReservationService.GetAllCommercantFoodReservation(id);

            return Ok(list.Result);
        }
        [HttpGet("GetCommercantLodgingReservation")]
        public IActionResult GetCommercantLodgingReservation(string id)

        {
            var list = LodgingReservationService.GetAllCommercantLodgingReservation(id);

            return Ok(list.Result);
        }
        [HttpGet("GetHostExperienceReservation")]
        public IActionResult GetHostExperienceReservation(string id)

        {
            var list = ReservationExperienceService.GetAllHostsExperiencesReservation(id);

            return Ok(list.Result);
        }


    }
}
