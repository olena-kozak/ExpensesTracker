using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.Models;

namespace NewExTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private IPlaceService _placeService;
        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }
        //Add place request
        [HttpPost]
        public IActionResult AddPlace([FromBody] PlaceRequest placeRequestMessage)
        {
            if (placeRequestMessage == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_placeService.PlaceExist(placeRequestMessage.OTPSmartName))
            {
                ModelState.AddModelError("", "This place exists");
                return StatusCode(404, ModelState);
            }

            if (!_placeService.CreatePlace(placeRequestMessage))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {placeRequestMessage.OTPSmartName}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    }
}
