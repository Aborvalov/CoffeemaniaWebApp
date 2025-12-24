using CoffeemaniaWebApp.Logics;
using CoffeemaniaWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeemaniaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceCalculator distanceCalculator;
        private readonly ILogger<DistanceController> logger;

        public DistanceController(IDistanceCalculator distanceCalculator, ILogger<DistanceController> logger)
        {
            this.distanceCalculator = distanceCalculator;
            this.logger = logger;
        }

        [HttpPost("calculate")]
        public IActionResult CalculateDistance([FromBody] DistanceRequest request)
        {
            try
            {
                if (request?.Point1 == null || request?.Point2 == null)
                    return BadRequest("Both points must be provided");

                if (!Helpers.IsValidCoordinate(request.Point1) ||
                    !Helpers.IsValidCoordinate(request.Point2))
                    return BadRequest("Invalid coordinates. Latitude must be between -90 and 90, Longitude between -180 and 180");

                var distance = distanceCalculator.CalculateDistance(request.Point1, request.Point2);

                logger.LogInformation(
                    "Calculated distance between ({Lat1}, {Lon1}) and ({Lat2}, {Lon2}): {Distance} km",
                    request.Point1.X, request.Point1.Y,
                    request.Point2.X, request.Point2.Y,
                    distance);

                return Ok(Math.Round(distance, 2));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error calculating distance");
                return StatusCode(500, "An error occurred while calculating distance");
            }
        }

        [HttpGet("calculate")]
        public IActionResult CalculateDistanceGet(
            [FromQuery] double lat1,
            [FromQuery] double lon1,
            [FromQuery] double lat2,
            [FromQuery] double lon2)
        {
            try
            {
                if (!Helpers.IsValidCoordinate(lat1, lon1) || !Helpers.IsValidCoordinate(lat2, lon2))
                    return BadRequest("Invalid coordinates. Latitude must be between -90 and 90, Longitude between -180 and 180");

                var point1 = new Point { X = lat1, Y = lon1 };
                var point2 = new Point { X = lat2, Y = lon2 };

                var distance = distanceCalculator.CalculateDistance(point1, point2);

                return Ok(Math.Round(distance, 2));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error calculating distance");
                return StatusCode(500, "An error occurred while calculating distance");
            }
        }
    }
}
