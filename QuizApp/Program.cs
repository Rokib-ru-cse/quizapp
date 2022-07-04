using Microsoft.EntityFrameworkCore;
using QuizApp.DataAccessLayer.Data;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.DataAccessLayer.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(p => p.AddPolicy("appcors", builder => { builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));


builder.Services.AddControllers();
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
app.UseCors("appcors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
