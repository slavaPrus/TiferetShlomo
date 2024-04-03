using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TiferetShlomoBL;
using TiferetShlomoDAL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

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
builder.Services.AddScoped<IJoiningDAL, JoiningDAL>();
builder.Services.AddScoped<IJoiningBL, JoiningBL>();
builder.Services.AddScoped<IPictureBL, PictureBL>();
builder.Services.AddScoped<IPictureDAL, PictureDAL>();
builder.Services.AddScoped<IPictureSaleBL, PictureSaleBL>();
builder.Services.AddScoped<IPictureSaleDAL, PictureSaleDAL>();
builder.Services.AddScoped<ITsfileBL, TsfileBL>();
builder.Services.AddScoped<ITsfileDAL, TsfileDAL>();
builder.Services.AddScoped<ITestDAL, TestDAL>();
builder.Services.AddScoped<ITestBL, TestBL>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<ILookUpBL, LookUpBL>();
builder.Services.AddScoped<ILookUpDAL, LookUpDAL>();
builder.Services.AddScoped<IMarkBL, MarkBL>();
builder.Services.AddScoped<IMarkDAL, MarkDAL>();

builder.Services.AddDbContext<TIFERET_SHLOMOContext>(options =>
    options.UseSqlServer("Server=DESKTOP-H37566O\\MSSQLSERVER01;Database=TIFERET_SHLOMO;Trusted_Connection=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();