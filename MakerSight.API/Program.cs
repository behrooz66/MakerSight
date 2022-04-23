using MakerSight.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// using an In-Memory database to give us the ORM features without having to setup an actual database
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "MakerSightDb"), ServiceLifetime.Singleton);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var ctx = app.Services.GetService<AppDbContext>();
if (ctx is not null)
{
    SeedDataCreator.AddSeedBrandsData(ctx);
    SeedDataCreator.AddSeedProductsData(ctx);
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
