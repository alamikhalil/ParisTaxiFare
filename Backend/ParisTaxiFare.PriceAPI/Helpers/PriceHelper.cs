namespace ParisTaxiFare.PriceAPI.Helpers
{
    /// <summary>
    /// The price helper class.
    /// </summary>
    internal static class PriceHelper
    {
        /// <summary>
        /// Gets the period coefficient.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <returns>The period coefficient.</returns>
        internal static decimal GetPeriodCoefficient(DateTime startTime)
        {
            if (startTime.Hour >= 6 && startTime.Hour <= 15)
            {
                return 1M;
            }

            if (startTime.Hour >= 16 && startTime.Hour <= 19)
            {
                return 2M;
            }
            
            return 1.5M;
        }
    }
}
