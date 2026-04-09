using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using tim_BackendTest_MidLevel.Models;
using tim_BackendTest_MidLevel.SwaggerExamples;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Myoffice_ACPDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExamplesFromAssemblyOf<MyOfficeAcpdCreateRequestExample>();
builder.Services.AddSwaggerGen(options =>
{
  options.ExampleFilters();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
