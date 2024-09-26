
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



            app.ConfigureationLibraryEndpoint();

            app.Run();
        }
    }
}
