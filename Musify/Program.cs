
using Core.DomainLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Logic.ServiceLayer.IServices;
using Logic.ServiceLayer.Services;
using Data.RepositoryLayer.IRepository;
using Data.RepositoryLayer.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//TO DO: Set a configurable value
builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//TO DO: Update Swagger documentation with Bearer Token
builder.Services.AddSwaggerGen();

//TO DO: Use configurable options
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            //TO DO: Replace hardcoded values with configurable options
            ValidIssuer = "AROBS.Trainees",
            ValidAudience = "AROBS.Staff",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("!N0bodyHasToKnowThis!")
            ),

            ClockSkew = TimeSpan.Zero


        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //TO DO: Set development exception handlers
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    //TO DO: Set production exception handler

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
