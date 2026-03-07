using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MonolithAPI.DBContext;
using MonolithAPI.Mapping;
using MonolithAPI.Repository.Implementation;
using MonolithAPI.Repository.Interface;
using MonolithAPI.Services.Implementation;
using MonolithAPI.Services.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IApplicationRepo,ApplicationRepo>();

builder.Services.AddDbContext<ApplicationDBContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDB"));

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {

    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {

        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWTSettings:Audience"],
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWTSettings").GetValue<string>("SymmetricKey")!)),


    };

});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IApplicationRepo,ApplicationRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(
        
        );


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
