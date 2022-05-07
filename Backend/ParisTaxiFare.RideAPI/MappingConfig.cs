using AutoMapper;
using ParisTaxiFare.RideAPI.Data.Dao;
using ParisTaxiFare.RideAPI.Models;
using ParisTaxiFare.RideAPI.Models.Dto;

namespace ParisTaxiFare.RideAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Ride, RideDto>();
                config.CreateMap<RideDao, Ride>();
            });
            return mappingConfig;
        }
    }
}