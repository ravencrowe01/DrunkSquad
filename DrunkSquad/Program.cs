using DrunkSquad.Database;
using DrunkSquad.Logic.User;
using DrunkSquad.Logic.User.Login;
using DrunkSquad.Logic.User.Registration;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TornApi.Net.REST;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.
builder.Services.AddControllersWithViews ();

AddServices (builder);

builder.Services.AddDbContext<DBAccess> (options => options.UseNpgsql(builder.Configuration.GetConnectionString("local")));

var app = builder.Build ();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment ()) {
    app.UseExceptionHandler ("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts ();
}

app.UseHttpsRedirection ();
app.UseStaticFiles ();

app.UseRouting ();

app.UseAuthorization ();

app.MapControllerRoute (
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run ();

void AddServices (WebApplicationBuilder builder) {
    IServiceCollection services = builder.Services;

    services.AddSingleton<IConfigurationManager> (builder.Configuration)
        .AddSingleton<IHttpClientFactory> (DefaultApiRequestClientFactory.Instance)
        .AddSingleton<IPasswordHasher<LoginDetails>, PasswordHasher<LoginDetails>> ()
        .AddSingleton<ILoginHandler, LoginHandler> ()
        .AddSingleton<IRegistrationHandler, RegistrationHandler> ();
}