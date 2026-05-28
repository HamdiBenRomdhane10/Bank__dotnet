using AutoMapper;
using Bank.Services.AccountAPI.Models;
using Bank.Services.AccountAPI.Models.Dto;

namespace Bank.Services.AccountAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AccountsDto, Accounts>();
                config.CreateMap<Accounts, AccountsDto>();

         
            });
            return mappingConfig;
        }
    }
}
