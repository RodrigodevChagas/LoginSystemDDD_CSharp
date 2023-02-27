using Microsoft.AspNetCore.Authentication.Cookies;
using SistemaDeLogin.Configurations;
using SistemaDeLogin.Infra.CrossCutting.Identity;
using SistemaDeLogin.Infra.CrossCutting.Identity.ConfigEmail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjectionConfiguration();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddWebAppIdentityConfig(builder.Configuration);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>{
        options.LoginPath = "Login/Index";
        options.Cookie.Name = "SistemaLoginCookies";
    });

builder.Services.AddAutoMapperConfiguration();
var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfig>();
builder.Services.AddSingleton(emailConfig);

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
