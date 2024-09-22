using SUT23LibraryProj.Models.DTOs;

namespace WebLibrary.Services
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetBookByID<T>(int id);
        Task<T> GetBookByTitle<T>(string name);
        Task<T> CreateBookAsync<T>(CreateBookDTO c_book_DTO);
        Task<T> UpdateBookAsync<T>(UpdateBookInfoDTO u_book_DTO);
        Task<T> UpdateBookStockAsync<T>(UpdateBookStockDTO u_book_s_DTO);
        Task<T> DeleteBookAsync<T>(int id);
    }
}
