using Microsoft.Extensions.DependencyInjection;
using TiferetShlomoBL;
using TiferetShlomoDAL;
using TiferetShlomoDTO.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddScoped<IBookDAL, BookDAL>();
builder.Services.AddScoped<IBookBL, BookBL>();
builder.Services.AddScoped<IBookPartDAL, BookPartDAL>();
builder.Services.AddScoped<IBookPartBL, BookPartBL>();
builder.Services.AddScoped<IContactDAL, ContactDAL>();
builder.Services.AddScoped<IContactBL, ContactBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
