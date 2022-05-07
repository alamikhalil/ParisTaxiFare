using AutoMapper;
using Flurl;
using Flurl.Http;
using Microsoft.EntityFrameworkCore;
using ParisTaxiFare.RideAPI.Data;
using ParisTaxiFare.RideAPI.Data.Dao;
using ParisTaxiFare.RideAPI.Models;
using ParisTaxiFare.RideAPI.Models.Dto;

namespace ParisTaxiFare.RideAPI.Services
{
    public class RideService : IRideService
    {
        private readonly IConfiguration _config;

        private readonly RideDbContext _rideDb;

        private readonly IMapper _mapper;

        private readonly string _priceApiUrl;

        public RideService(IConfiguration config, RideDbContext rideDb, IMapper mapper)
        {
            _config = config;
            _priceApiUrl = _config.GetValue<string>("Endpoints:PriceApiUrl");
            _rideDb = rideDb;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="withPrice">if set to <c>true</c> [with price].</param>
        /// <returns>
        /// Enumeration of rides.
        /// </returns>
        public async Task<IEnumerable<Ride>> GetAllAsync(bool withPrice)
        {
            var rideDaoList = await _rideDb.Rides.ToListAsync();
            var rideList = _mapper.Map<List<Ride>>(rideDaoList);

            if (withPrice)
            {
                foreach (var ride in rideList)
                {
                    ride.Price = await GetPrice(ride.Distance, ride.StartTime);
                }
            }

            return rideList;
        }

        /// <summary>
        /// Gets the ride by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="withPrice">if set to <c>true</c> [with price].</param>
        /// <returns>
        /// The ride by identifier.
        /// </returns>
        public async Task<Ride> GetByIdAsync(long id, bool withPrice)
        {
            var rideDao = await _rideDb.FindAsync<RideDao>(id);
            var ride = _mapper.Map<Ride>(rideDao);

            if (withPrice)
            {
                ride.Price = await GetPrice(ride.Distance, ride.StartTime);
            }

            return ride;
        }

        /// <summary>
        /// Gets the price from the PriceAPI.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="startTime">The start time.</param>
        /// <returns>The price from the PriceAPI.</returns>
        private async Task<decimal?> GetPrice(long distance, DateTime startTime)
        {
            var priceDto = await _priceApiUrl
                .AppendPathSegment("price")
                .SetQueryParam("distance", distance)
                .SetQueryParam("startTime", startTime)
                .GetJsonAsync<PriceDto>();

            return priceDto?.Price;
        }
    }
}