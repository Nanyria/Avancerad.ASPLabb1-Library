using Newtonsoft.Json;
using System.Text;
using WebLibrary.Models;

namespace WebLibrary.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO responseModel { get; set; }
        public IHttpClientFactory _HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            _HttpClient = httpClient;
            responseModel = new ResponseDTO();
        }
        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = _HttpClient.CreateClient("SUT23LibraryAPI");

                HttpRequestMessage message = new()
                {
                    Headers = { { "Accept", "application/json" } }, // Säger att vi vill ha json tillbaka
                    RequestUri = new Uri(apiRequest.Url) // Säger vilken url vi ska göra requesten till
                };
                
                client.DefaultRequestHeaders.Clear(); //Rensar alla headers


                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent
                        (
                        JsonConvert
                        .SerializeObject(apiRequest.Data), 
                        Encoding.UTF8, "application/json"
                        );
                }

                HttpResponseMessage apiResponse = null;
                // Switch som väljer typ av request
                switch (apiRequest.aPIType)
                {
                    case StaticDetails.APIType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.APIType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        break;
                }

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent); // Deserialiserar json till objekt

                return apiResponseDTO;
            }
            catch (Exception e)
            {

                var dto = new ResponseDTO
                {

                    DisplayMessages = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };

                var result = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(result);
                return apiResponseDto;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }


    }
}
