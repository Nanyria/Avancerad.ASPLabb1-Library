using AutoMapper;
using static Azure.Core.HttpHeader;
using SUT23LibraryProj.Models;
using SUT23LibraryProj.Models.DTOs;
using SUT23LibraryProj.Repositories;

namespace SUT23LibraryProj.EndPoints
{
    public static class LibraryEndpoints
    {
        public static void ConfigureationLibraryEndpoint(this WebApplication app)
        {
            // Anropar MapGet-metoden för att skapa en endpoint för att hämta alla kuponger
            app.MapGet("/api/books", GetAllBooks).WithName("GetAllBooks").Produces<APIResponse>();

            // Anropar MapGet-metoden för att skapa en endpoint för att hämta en specifik kupong
            app.MapGet("/api/book/{id:int}", GetBookById).WithName("GetBookById").Produces<APIResponse>();

            // Anropar MapGet-metoden för att skapa en endpoint för att hämta en specifik kupong
            app.MapGet("/api/book/{title}", GetBookByTitle).WithName("GetBookByTitle").Produces<APIResponse>();

            // Anropar MapPost-metoden för att skapa en endpoint för att skapa en ny kupong
            app.MapPost("/api/book", AddBook)
                .WithName("AddBook")
                .Accepts<CreateBookDTO>("application/json")
                .Produces(201)
                .Produces(400); //Varför har vi inte <APIResponse> här? 2.10 inspelning 29/8



            app.MapPut("/api/book/", UpdateBookInfo)
                .WithName("UpdateBookInfo")
                .Accepts<UpdateBookInfoDTO>("application/json")
                .Produces<UpdateBookInfoDTO>(200)
                .Produces(400);


            app.MapPut("/api/book/{id:int}/stock", UpdateBookStock)
                .WithName("UpdateBookStock")
                .Accepts<UpdateBookStockDTO>("application/json")
                .Produces<UpdateBookStockDTO>(200)
                .Produces(400);
            //Anropar MapDelete-metoden för att skapa en endpoint för att ta bort en specifik kupong
            //app.MapDelete("/api/book/{id:int}", )
            //    .WithName("DeleteCoupon")
            //    .Produces(204)
            //    .Produces(400);
        }
        private async static Task<IResult> GetAllBooks(IBookRepo _bookRepo)
        {
            APIResponse response = new APIResponse();

            response.Result = await _bookRepo.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> GetBookById(IBookRepo _bookRepo, int id)
        {
            APIResponse response = new APIResponse();
            response.Result = await _bookRepo.GetByIdAsync(id);
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }
        private async static Task<IResult> GetBookByTitle(IBookRepo _bookRepo, int id)
        {
            APIResponse response = new APIResponse();
            response.Result = await _bookRepo.GetByIdAsync(id);
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }
        private async static Task<IResult> AddBook(IBookRepo _bookRepo,
            IMapper _mapper, CreateBookDTO c_Book_DTO)
        {

            APIResponse response = new()
            {
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };

            if (string.IsNullOrEmpty(c_Book_DTO.Title))
            {

                response.ErrorMessages.Add("Title must not be empty");
                return Results.BadRequest(response);
            }

            Book book = _mapper.Map<Book>(c_Book_DTO);
            await _bookRepo.CreateBookAsync(book);
            await _bookRepo.SaveAsync();

            BookDTO couponDTO = _mapper.Map<BookDTO>(book);
            response.Result = couponDTO;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.Created;

            return Results.Ok(response);


        }

        private async static Task<IResult> UpdateBookInfo(IBookRepo _bookRepo,
            IMapper _mapper, UpdateBookInfoDTO u_book_DTO)
        {
            APIResponse response = new()
            {
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };



            //if (_bookRepo.GetByNameAsync(u_coupon_dto.Name).GetAwaiter().GetResult() != null)
            //{
            //    response.ErrorMessages.Add("Coupon name already exists");
            //    return Results.BadRequest(response);
            //}

            await _bookRepo.UpdateAsync(_mapper.Map<Book>(u_book_DTO));
            await _bookRepo.SaveAsync();


            response.Result = _mapper.Map<UpdateBookInfoDTO>(await _bookRepo.GetByIdAsync(u_book_DTO.BookID));
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);

        }

        private async static Task<IResult> UpdateBookStock(IBookRepo _bookRepo,
            IMapper _mapper, int id, UpdateBookStockDTO u_book_s_DTO)
        {
            APIResponse response = new()
            {
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };


            await _bookRepo.UpdateAsync(_mapper.Map<Book>(u_book_s_DTO));
            await _bookRepo.SaveAsync();


            response.Result = _mapper.Map<UpdateBookStockDTO>(await _bookRepo.GetByIdAsync(u_book_s_DTO.BookID));
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);

            //private async static Task<IResult> DeleteCoupon(ICouponRepo _couponRepo, int id)
            //{
            //    APIResponse response = new()
            //    {
            //        IsSuccess = false,
            //        StatusCode = System.Net.HttpStatusCode.BadRequest
            //    };

            //    Coupon couponFromDb = await _couponRepo.GetByIdAsync(id);

            //    if (couponFromDb != null)
            //    {
            //        await _couponRepo.RemoveAsync(couponFromDb);
            //        await _couponRepo.SaveAsync();
            //        response.IsSuccess = true;
            //        response.StatusCode = System.Net.HttpStatusCode.NoContent;

            //        return Results.Ok(response);
            //    }
            //    else
            //    {
            //        response.ErrorMessages.Add("Invalid ID");
            //        return Results.BadRequest(response);
            //    }

            //}
        }
    }
}

