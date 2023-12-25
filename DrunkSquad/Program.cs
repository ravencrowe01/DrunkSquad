using DrunkSquad.Database;
using DrunkSquad.Logic.User.Login;
using DrunkSquad.Logic.User.Registration;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.REST;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.
builder.Services.AddControllersWithViews ();

AddServices (builder);

// Auto generated by ChatGPT
builder.Services.AddDbContext<DrunkSquadDBContext> ((provider, options) => {
    WebsiteConfig websiteConfig = (WebsiteConfig) provider.GetRequiredService<IWebsiteConfig> ();

    options.UseNpgsql (websiteConfig.GetConnectionString ("Local"));
});

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

    services.AddSingleton<IConfiguration> (builder.Configuration);
    services.AddSingleton<IWebsiteConfig, WebsiteConfig>((services) => new WebsiteConfig (services.GetService<IConfiguration> ()));

    services.AddSingleton<IHttpClientFactory> (DefaultApiRequestClientFactory.Instance);

    services.AddScoped<IPasswordHasher<LoginDetails>, PasswordHasher<LoginDetails>>();

    services.AddScoped<ILoginHandler, LoginHandler> ();
    services.AddScoped<IRegistrationHandler, RegistrationHandler> ();
}