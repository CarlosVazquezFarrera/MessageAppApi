using MessageApp.Data;
using MessageApp.Hubs;
using MessageApp.Interfaces;
using MessageApp.Mapping;
using MessageApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:4200") // URL de tu app Angular
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // Permite enviar cookies o credenciales
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IStudentService, StudentService>();

builder.Services.AddDbContext<MessagesAppContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<MessageHub>("/messageHub").RequireCors(MyAllowSpecificOrigins);


app.Run();
