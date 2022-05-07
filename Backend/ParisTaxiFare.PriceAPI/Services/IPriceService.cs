namespace ParisTaxiFare.PriceAPI.Services
{
    /// <summary>
    ///   Price service interface.
    /// </summary>
    public interface IPriceService
    {
        /// <summary>
        /// Calculates the ride price.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="startTime">The start time.</param>
        /// <returns>The ride price.</returns>
        decimal CalculateRidePrice(int distance, DateTime startTime);
    }
}