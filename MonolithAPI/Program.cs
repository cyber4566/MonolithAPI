using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

var keyVaultUrl = new Uri("https://secretmanager1.vault.azure.net/");


if (builder.Environment.IsProduction()) {

    builder.Configuration.AddAzureKeyVault(
     keyVaultUrl,
         new ClientSecretCredential(
         builder.Configuration["AppRegistration:TenantID"],
         builder.Configuration["AppRegistration:ClientID"],
         builder.Configuration["AppRegistration:ClientSecret"]
     )
 );


}
else
{

    builder.Configuration.AddAzureKeyVault(
     keyVaultUrl,
     new DefaultAzureCredential()
   );

}


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


builder.Services.AddCors(options => {
    options.AddPolicy("AllowUI", policy => { 
    
         policy.AllowAnyHeader();
         policy.WithOrigins("http://localhost:4200");
         policy.AllowAnyMethod();
    });

});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IApplicationRepo,ApplicationRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(
        
        );

app.UseCors("AllowUI");
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
