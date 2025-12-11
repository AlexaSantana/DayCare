using DayCare.Application.Services;
using DayCare.Infrastructure.Data;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DayCareDbContext>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DayCareConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy
            .WithOrigins("https://localhost:7264") // Aquí debe ir la URL de tu Blazor
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddScoped<ITutorService, TutorService>();
builder.Services.AddScoped<IChildService, ChildService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DayCareDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI(); 

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowBlazor");
app.MapControllers();

app.Run();
