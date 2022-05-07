using ParisTaxiFare.RideAPI.Models;

namespace ParisTaxiFare.RideAPI.Services
{
    public interface IRideService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="withPrice">if set to <c>true</c> [with price].</param>
        /// <returns>
        /// Enumeration of rides.
        /// </returns>
        Task<IEnumerable<Ride>> GetAllAsync(bool withPrice);

        /// <summary>
        /// Gets the ride by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="withPrice">if set to <c>true</c> [with price].</param>
        /// <returns>The ride by identifier.</returns>
        Task<Ride> GetByIdAsync(long id, bool withPrice);
    }
}
