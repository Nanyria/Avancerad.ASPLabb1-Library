using SUT23LibraryProj.Models.DTOs;
using WebLibrary.Models;

namespace WebLibrary.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;

        }
        public async Task<T> CreateBookAsync<T>(CreateBookDTO c_book_DTO)
        {
            return await SendAsync<T>(new APIRequest
            {
                aPIType = StaticDetails.APIType.POST,
                Data = c_book_DTO,
                Url = StaticDetails.LibraryAPIBase + "/api/book",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int bookId)
        {
            return await SendAsync<T>(new APIRequest
            {
                aPIType = StaticDetails.APIType.DELETE,
                Url = StaticDetails.LibraryAPIBase + "/api/book/" + bookId,
                AccessToken = "",
            });
        }

        public async Task<T> GetAllBooks<T>()
        {
            return await SendAsync<T>(new APIRequest
            {
                aPIType = StaticDetails.APIType.GET,
                Url = StaticDetails.LibraryAPIBase + "/api/books",
                AccessToken = "",
            });
        }

        public async Task<T> GetBookByID<T>(int bookId)
        {
            return await SendAsync<T>(new APIRequest
            {
                aPIType = StaticDetails.APIType.GET,
                Url = StaticDetails.LibraryAPIBase + "/api/book/" + bookId,
                AccessToken = "",
            });
        }

        public async Task<T> GetBookByTitle<T>(string bookTitle)
        {
            return await SendAsync<T>(new APIRequest
            {
                aPIType = StaticDetails.APIType.GET,
                Url = StaticDetails.LibraryAPIBase + "/api/book/" + bookTitle,
                AccessToken = "",
            });
        }

        public async Task<T> UpdateBookAsync<T> (UpdateBookInfoDTO u_book_DTO)
        {
            return await SendAsync<T>(new APIRequest
            {
                aPIType = StaticDetails.APIType.PUT,
                Data = u_book_DTO,
                Url = StaticDetails.LibraryAPIBase + "/api/book",
                AccessToken = "",
            });
        }

        public async Task<T> UpdateBookStockAsync<T>(UpdateBookStockDTO u_book_s_DTO)
        {
            return await SendAsync<T>(new APIRequest
            {
                aPIType = StaticDetails.APIType.PUT,
                Data = u_book_s_DTO,
                Url = StaticDetails.LibraryAPIBase + "/api/book/stock" ,
                AccessToken = "",
            });
        }


    }
}
