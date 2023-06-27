
using Core.DomainLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Logic.ServiceLayer.IServices;
using Logic.ServiceLayer.Services;
using Data.RepositoryLayer.IRepository;
using Data.RepositoryLayer.Repository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//TO DO: Set a configurable value
builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test"));


// ADD Dependencies here

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// STOP adding dependency

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Endpoints", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
                {
                        new OpenApiSecurityScheme
                        {
                                Reference = new OpenApiReference
                                {
                                        Type=ReferenceType.SecurityScheme,
                                        Id="Bearer"
                                }
                        },
                        new string[]{}
                }
        });
});


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
