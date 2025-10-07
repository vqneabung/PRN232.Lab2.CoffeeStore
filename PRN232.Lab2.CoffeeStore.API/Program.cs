using Common.Middlewares;
using DotNetEnv;
using DotNetEnv.Configuration;
using PRN232.Lab2.CoffeeStore.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Load .env manually in Development
if (builder.Environment.IsDevelopment())
{
    builder.Configuration
    .AddDotNetEnv(".env", LoadOptions.TraversePath()) // Simply add the DotNetEnv configuration source!
    .Build();
}

builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
