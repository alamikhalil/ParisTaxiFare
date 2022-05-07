using Microsoft.AspNetCore.Mvc;
using ParisTaxiFare.RideAPI.Models.Dto;
using ParisTaxiFare.RideAPI.Services;

namespace ParisTaxiFare.RideAPI.Controllers
{
    [ApiController]
    [Route("rides")]
    public class RideController : ControllerBase
    {
        private readonly IRideService _rideService;

        public RideController(IRideService rideService)
        {
            _rideService = rideService;
        }

        [HttpGet(Name = "GetRides")]
        public async Task<IActionResult> Get([FromQuery] bool withPrice = false)
        {
            var rides = await _rideService.GetAllAsync(withPrice);

            return Ok(new ResponseDto
            {
                Result = rides
            });
        }

        [HttpGet("{id}",Name = "GetRide")]
        public async Task<IActionResult> Get(long id, [FromQuery] bool withPrice = false)
        {
            var ride = await _rideService.GetByIdAsync(id, withPrice);

            return Ok(new ResponseDto
            {
                Result = ride
            });
        }

    }
}