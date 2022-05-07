using ParisTaxiFare.PriceAPI.Helpers;

namespace ParisTaxiFare.PriceAPI.Services
{
    /// <summary>
    /// Price service.
    /// </summary>
    /// <seealso cref="ParisTaxiFare.PriceAPI.Services.IPriceService" />
    public class PriceService : IPriceService
    {
        /// <summary>
        /// Calculates the ride price.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="startTime">The start time.</param>
        /// <returns>
        /// The ride price.
        /// </returns>
        public decimal CalculateRidePrice(int distance, DateTime startTime)
        {
            return 1 + distance * 5 * PriceHelper.GetPeriodCoefficient(startTime);
        }
    }
}