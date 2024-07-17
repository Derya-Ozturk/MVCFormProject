using Business.Abstract;
using Business.Concrete;
using Business.Mapping;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(opt => 
            { 
                opt.LoginPath = "/Login/Index";
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddSingleton<ILoginService, LoginManager>();
builder.Services.AddSingleton<ILoginDal, EfLoginDal>();
builder.Services.AddSingleton<IFormService, FormManager>();
builder.Services.AddSingleton<IFormDal, EfFormDal>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
