
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SUT23LibraryProj.Data;
using SUT23LibraryProj.EndPoints;
using SUT23LibraryProj.Models;
using SUT23LibraryProj.Models.DTOs;
using SUT23LibraryProj.Repositories;
using System;
using System.Reflection.Metadata.Ecma335;

namespace SUT23LibraryProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingConfig));

            //Register DB provider
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionToDB")));

            builder.Services.AddScoped<IBookRepo, BookRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapGet("/api/books", () =>
            //{
            //    APIResponse response = new APIResponse();
            //    response.Result = LibraryTestObjects.bookList;
            //    response.IsSuccess = true;
            //    response.StatusCode = System.Net.HttpStatusCode.OK;


            //    return Results.Ok(response);

            //}).WithName("GetAllBooks").Produces<IEnumerable<Book>>(200);

            //app.MapGet("api/book/{id:int}", (int id) =>
            //{
            //    APIResponse response = new APIResponse();
            //    var book = LibraryTestObjects.bookList.FirstOrDefault(b => b.BookID == id);

            //    if (book == null)
            //    {
            //        response.IsSuccess = false;
            //        response.StatusCode = System.Net.HttpStatusCode.NotFound;
            //        response.ErrorMessages.Add("Book not found");
            //        return Results.NotFound(response);
            //    }

            //    response.Result = book;
            //    response.IsSuccess = true;
            //    response.StatusCode = System.Net.HttpStatusCode.OK;

            //    return Results.Ok(response);
            //}).WithName("GetBookById").Produces<Book>(200);


            //app.MapGet("api/book/{title}", (string title) =>
            //{
            //    APIResponse response = new APIResponse();
            //    var book = LibraryTestObjects.bookList.FirstOrDefault(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            //    if (book == null)
            //    {
            //        response.IsSuccess = false;
            //        response.StatusCode = System.Net.HttpStatusCode.NotFound;
            //        response.ErrorMessages.Add("Book not found");
            //        return Results.NotFound(response);
            //    }

            //    response.Result = book;
            //    response.IsSuccess = true;
            //    response.StatusCode = System.Net.HttpStatusCode.OK;

            //    return Results.Ok(response);
            //}).WithName("GetBookByTitle").Produces<Book>(200);

            //app.MapPost("api/book", async (IMapper _mapper, CreateBookDTO c_book_dto) =>
            //{

            //    APIResponse response = new()
            //    {
            //        IsSuccess = false,
            //        StatusCode = System.Net.HttpStatusCode.BadRequest
            //    };

            //    if (string.IsNullOrEmpty(c_book_dto.Title))
            //    {
            //        response.ErrorMessages.Add("Title must not be empty");
            //        return Results.BadRequest(response);
            //    }

            //    //V�ljer att inte l�gga in ett if-sats f�r boknamnet d� flera b�cker kan ha samma namn.
            //    //Ska man g�ra det b�r man �ven inkludera f�rfattare f�r att undvika dubletter, men t�nker att det inte �r ett krav.
                
            //    //AutoMapper
            //    Book book = _mapper.Map<Book>(c_book_dto);
            //    book.BookID = LibraryTestObjects.bookList.OrderByDescending(c => c.BookID).FirstOrDefault().BookID + 1;
            //    LibraryTestObjects.bookList.Add(book);

            //    BookDTO bookDTO = _mapper.Map<BookDTO>(book);

            //    response.Result = bookDTO;
            //    response.IsSuccess = true;
            //    response.StatusCode = System.Net.HttpStatusCode.Created;

            //    return Results.Created($"/api/book/{bookDTO.BookID}", response);


            //}).WithName("AddBook").Produces<CreateBookDTO>(201).Produces(400);

            //app.MapPut("api/book/", (IMapper _mapper, UpdateBookInfoDTO u_book_dto) =>
            //{
            //    APIResponse response = new()
            //    {
            //        IsSuccess = false,
            //        StatusCode = System.Net.HttpStatusCode.BadRequest
            //    };
            //    if (string.IsNullOrEmpty(u_book_dto.Title))
            //    {

            //        response.ErrorMessages.Add("Title must not be empty");
            //        return Results.BadRequest(response);
            //    }

            //    Book bookToUpdate = LibraryTestObjects.bookList.FirstOrDefault(b => b.BookID == u_book_dto.BookID);
            //    bookToUpdate.Author = u_book_dto.Author;
            //    bookToUpdate.Genre = u_book_dto.Genre;
            //    bookToUpdate.Title = u_book_dto.Title;
            //    bookToUpdate.PublicationYear = u_book_dto.PublicationYear;
            //    bookToUpdate.BookDescription = u_book_dto.BookDescription;

            //    Book book = _mapper.Map<Book>(bookToUpdate);
                
            //    response.Result = _mapper.Map<UpdateBookInfoDTO>(book);
            //    response.IsSuccess = true;
            //    response.StatusCode = System.Net.HttpStatusCode.OK;
            //    return Results.Ok(response);

            //}).WithName("UpdateBook").Produces<UpdateBookInfoDTO>(200).Produces(400);


            //app.MapPut("api/book/{id:int}/stock", (IMapper _mapper, int id, UpdateBookStockDTO u_book_dto) =>
            //{
            //    APIResponse response = new()
            //    {
            //        IsSuccess = false,
            //        StatusCode = System.Net.HttpStatusCode.BadRequest
            //    };

            //    Book bookToUpdate = LibraryTestObjects.bookList.FirstOrDefault(b => b.BookID == id);
            //    if (bookToUpdate == null)
            //    {
            //        response.ErrorMessages.Add("Book not found");
            //        return Results.BadRequest(response);
            //    }

            //    bookToUpdate.IsInStock = u_book_dto.IsInStock;

            //    response.Result = _mapper.Map<UpdateBookInfoDTO>(bookToUpdate);
            //    response.IsSuccess = true;
            //    response.StatusCode = System.Net.HttpStatusCode.OK;

            //    return Results.Ok(response);

            //}).WithName("UpdateBookStock").Produces<UpdateBookInfoDTO>(200).Produces(400);

            app.MapDelete("api/book/{id}", (int id) =>
            {
                APIResponse response = new()
                {
                    IsSuccess = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
                Book book = LibraryTestObjects.bookList.FirstOrDefault(b => b.BookID == id);
                if (book == null)
                {
                    response.ErrorMessages.Add("Invalid ID");
                    return Results.BadRequest(response);
                }
                LibraryTestObjects.bookList.Remove(book);
                response.IsSuccess = true;
                response.StatusCode=System.Net.HttpStatusCode.OK;
                return Results.Ok(response);
            }).WithName("DeleteBook").Produces(404);


            app.ConfigureationLibraryEndpoint();

            app.Run();
        }
    }
}
