using Microsoft.AspNetCore.Mvc;
using ParisTaxiFare.PriceAPI.Models.Dto;
using ParisTaxiFare.PriceAPI.Services;

namespace ParisTaxiFare.PriceAPI.Controllers
{
    [ApiController]
    [Route("price")]
    public class PriceController : ControllerBase
    {
        /// <summary>
        /// The price service
        /// </summary>
        private readonly IPriceService _priceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceController"/> class.
        /// </summary>
        /// <param name="priceService">The price service.</param>
        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        /// <summary>
        /// Gets the ride's price.
        /// </summary>
        /// <param name="distance">The ride's distance.</param>
        /// <param name="startTime">The ride's start time.</param>
        /// <returns>The ride's price.</returns>
        [HttpGet(Name = "GetPrice")]
        public IActionResult Get([FromQuery] int distance, [FromQuery] string startTime)
        {
            if (!DateTime.TryParse(startTime, out var startDateTime))
            {
                return BadRequest("startTime param has incorrect format.");
            }

            if (distance < 0)
            {
                return BadRequest("distance param has inacceptable value.");
            }

            return Ok(new PriceDto
            {
                Price = _priceService.CalculateRidePrice(distance, startDateTime),
            });
        }
    }
}