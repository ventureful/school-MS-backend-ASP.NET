using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentTodo.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

string json = JsonConvert.SerializeObject(builder.Configuration, Formatting.Indented);
Console.WriteLine(json);

builder.Services.AddDbContext<DbSchoolManagementContext>(options => {
    options.UseNpgsql("Username=postgres;Password=rkdwkrkehlfk;Host=localhost;Port=5432;Database=db_school_management;Pooling=true;");
});

builder.Services.AddCors(options => {
    options.AddPolicy("Cors", p => {
        p.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("Cors");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
