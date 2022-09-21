using MedikoData;
using MedikoServices;
using MedikoData.Entities;
using MedikoData.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connString = builder.Configuration.GetConnectionString("MedikoLocalhost");
builder.Services.AddDbContext<MedikoDbContext>(options =>
        options.UseSqlServer(connString));

builder.Services.AddTransient<LogBookService>();
builder.Services.AddTransient<ILogBookRepo, SQLLogBookRepo>();
builder.Services.AddTransient<LogsService>();
builder.Services.AddTransient<ILogsRepo, SQLLogsRepo>();

builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
{
    config.SignIn.RequireConfirmedEmail = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MedikoDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
