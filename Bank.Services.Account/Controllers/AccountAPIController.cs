using AutoMapper;
using Bank.Services.AccountAPI.Data;
using Bank.Services.AccountAPI.Models;
using Bank.Services.AccountAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Services.AccountAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public AccountAPIController(AppDbContext db, IMapper mapper) {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Accounts> objList = _db.Accounts.ToList();
                _response.Result = _mapper.Map<IEnumerable<AccountsDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Accounts obj = _db.Accounts.First(u=>u.Id==id);
               _response.Result = _mapper.Map<AccountsDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByNumber/{number}")]
        public ResponseDto GetByNumber (string number)
        {
            try
            {
                Accounts obj = _db.Accounts.First(u => u.Number.ToLower() ==number.ToLower());
                if (obj == null)
                {
                    _response.IsSuccess = false;
                }
                _response.Result = _mapper.Map<AccountsDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] AccountsDto accountsDto)
        {
            try
            {
                Accounts obj = _mapper.Map<Accounts>(accountsDto);
                _db.Accounts.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<AccountsDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put ([FromBody] AccountsDto accountsDto)
        {
            try
            {
                Accounts obj = _mapper.Map<Accounts>(accountsDto);
                _db.Accounts.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<AccountsDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete (int id)
        {
            try
            {
                Accounts obj = _db.Accounts.First(u=>u.Id==id);
                _db.Accounts.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
