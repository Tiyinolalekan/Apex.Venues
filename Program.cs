using Microsoft.EntityFrameworkCore;
using Apex.Venues.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
// Add services to the container.

builder.Services.AddControllers();

// Register database context with the framework
builder.Services.AddDbContext<VenuesDbContext>();

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(
        options => options.WithOrigins("*").AllowAnyMethod()
    );

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
