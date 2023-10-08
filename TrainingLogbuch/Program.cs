using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MVC_Frontend.Repositories;
using Assignment1;

var builder = WebApplication.CreateBuilder(args);


//TEST
// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext (if not done yet)
var connectionString = builder.Configuration.GetConnectionString("TrainingDatabase");
builder.Services.AddDbContext<TrainingContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
// Register the repository
builder.Services.AddScoped<IMyRepository, MyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Training}/{action=Index}/{id?}");

app.Run();

//TEST UGI5
