using Bank.Web.Models;
using Bank.Web.Service.IService;
using Bank.Web.Utility;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank.Web.Service
{
    public class AccountService : IAccountService
    {
        private readonly IBaseService _baseService;
       
        public AccountService(IBaseService baseService)
        {
            _baseService = baseService;
            
        }

         public async Task<ResponseDto?> CreateAccountsAsync(AccountsDto accountDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = accountDto,
                Url = SD.AccountAPIBase + "/api/account" 
            }); 
        }

         public async Task<ResponseDto?> DeleteAccountsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AccountAPIBase + "/api/account/" + id
            });
        }

        public async Task<ResponseDto?> GetAccountsAsync(string number)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AccountAPIBase + "/api/account/GetByNumber/" + number
            });
        }

         public async Task<ResponseDto?>GetAccountsByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AccountAPIBase + "/api/account/" + id
            });
        }

        public async Task<ResponseDto?> GetAllAccountsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AccountAPIBase + "/api/account"
            });
        }

        public async Task<ResponseDto?> UpdateAccountsAsync(AccountsDto accountDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = accountDto,
                Url = SD.AccountAPIBase + "/api/account"
            });
        }
    }
}
