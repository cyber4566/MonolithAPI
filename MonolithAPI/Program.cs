using Microsoft.EntityFrameworkCore;
using MonolithAPI.DBContext;
using MonolithAPI.Repository.Implementation;
using MonolithAPI.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IApplicationRepo,ApplicationRepo>();

builder.Services.AddDbContext<ApplicationDBContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDB"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
