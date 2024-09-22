using AutoMapper;
using SUT23LibraryProj.Models;
using SUT23LibraryProj.Models.DTOs;

namespace SUT23LibraryProj
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, CreateBookDTO>().ReverseMap();
            CreateMap<Book, UpdateBookStockDTO>().ReverseMap();
            CreateMap<Book, UpdateBookInfoDTO>().ReverseMap();
        }
    }
}
