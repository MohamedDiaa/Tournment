using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Tournament.Data;
using Tournament.Core;
using Tournament.Api.Extensions;
using Tournament.Core.Repositories;
using Tournament.Data.Repositories;

namespace Tournament.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();

            builder.Services.AddControllers(opt => opt.ReturnHttpNotAcceptable = true)
                .AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          
            builder.Services.AddDbContext<TournmentDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TournmentDbContext") ?? throw new InvalidOperationException("Connection string 'GarageMVCContext' not found.")));

            builder.Services.AddScoped<IUnitofWork, UnitofWork>();

            var app = builder.Build();

             app.SeedDataAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
