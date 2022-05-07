using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParisTaxiFare.RideAPI;
using ParisTaxiFare.RideAPI.Data;
using ParisTaxiFare.RideAPI.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder
                          .WithOrigins("https://localhost:3000", "http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});


// Add services to the container.
builder.Services.AddDbContext<RideDbContext>(options => options.UseSqlite("Name=RideDB"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRideService, RideService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
