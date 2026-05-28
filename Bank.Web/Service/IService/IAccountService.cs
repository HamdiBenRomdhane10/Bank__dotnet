using Bank.Web.Models;

namespace Bank.Web.Service.IService
{
    public interface IAccountService
    {
        Task<ResponseDto?> GetAccountsAsync(string number);
        Task<ResponseDto?> GetAllAccountsAsync();
        Task<ResponseDto?> GetAccountsByIdAsync(int id);
        Task<ResponseDto?> CreateAccountsAsync(AccountsDto accountDto);
        Task<ResponseDto?> UpdateAccountsAsync(AccountsDto accountDto);
        Task<ResponseDto?> DeleteAccountsAsync(int id);
    }
}
