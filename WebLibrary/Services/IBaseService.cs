using WebLibrary.Models;

namespace WebLibrary.Services
{
    public interface IBaseService : IDisposable //Gör så att data som inte behövs släpps automatiskt så att det inte tuggar onödigt på minnet
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest); //Sköter http client request

    }
}
