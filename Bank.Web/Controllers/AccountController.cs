using Bank.Web.Models;
using Bank.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bank.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IActionResult> AccountIndex()
        {
            List<AccountsDto>? list = new();

            ResponseDto? response = await _accountService.GetAllAccountsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AccountsDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["Error"] = response?.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> AccountCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AccountCreate(AccountsDto model)
        {
            if(ModelState.IsValid)
            {

                ResponseDto? response = await _accountService.CreateAccountsAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["Success"] = "Account created successfully.";
                    return RedirectToAction(nameof(AccountIndex));
                }
                else
                {
                    TempData["Error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> AccountDelete(int id)
        {
            ResponseDto? response = await _accountService.GetAccountsByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                AccountsDto? model = JsonConvert.DeserializeObject<AccountsDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["Error"] = response?.Message;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AccountDelete(AccountsDto accountsDto)
        {
            ResponseDto? response = await _accountService.DeleteAccountsAsync(accountsDto.Id);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(AccountIndex));
            }
            else
            {
                TempData["Error"] = response?.Message;
            }
            return View(accountsDto);
        }
    }
}
