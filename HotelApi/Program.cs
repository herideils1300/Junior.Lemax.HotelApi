


using System.Text;
using HotelApi.Application;
using HotelApi.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Enter your token:",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition("Bearer", jwtSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:issuer"],
        ValidAudience = builder.Configuration["Jwt:issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
builder.Services.AddMemoryCache((options) =>
{
    options.ExpirationScanFrequency = TimeSpan.FromMinutes(3);
    options.SizeLimit = 1024;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors((builder) =>
{
    builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/user/token", () =>
{
    var token = AutoAuthHandler.HandleAuthenticateAsync(builder.Configuration);

    if (token == "")
    {
        return Results.Unauthorized();
    }

    return Results.Accepted(token);
});

app.MapControllers();

app.Run();
