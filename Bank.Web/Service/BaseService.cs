using Bank.Web.Models;
using Bank.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using static Bank.Web.Utility.SD;


namespace Bank.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient Client = _httpClientFactory.CreateClient("BankAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //token

                message.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), System.Text.Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await Client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Found"
                        };
                    case HttpStatusCode.Forbidden:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Access Denied"
                        };

                    case HttpStatusCode.Unauthorized:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unauthorized Access"
                        };

                    case HttpStatusCode.InternalServerError:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Internal Server Error"
                        };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;

                }

            }
            catch (Exception ex)
            {
                var Dto = new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString(),
                };
                return Dto;
            }
        }

    }
}

