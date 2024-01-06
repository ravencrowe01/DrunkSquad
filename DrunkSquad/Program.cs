using DrunkSquad.Database;
using DrunkSquad.Database.Accessors;
using DrunkSquad.Logic.Faction.Crimes;
using DrunkSquad.Logic.Faction.Info;
using DrunkSquad.Logic.Users;
using DrunkSquad.Logic.Users.Login;
using DrunkSquad.Logic.Users.Registration;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;
using TornApi.Net.REST;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.
builder.Services.AddControllersWithViews ();

AddServices (builder);
AddEntityAccessors (builder);

builder.Services.AddDbContext<DrunkSquadDBContext> ((provider, options) => {
    WebsiteConfig websiteConfig = (WebsiteConfig) provider.GetRequiredService<IWebsiteConfig> ();

    options.EnableDetailedErrors (true);
    options.UseSqlServer (websiteConfig.ApiConfig.DefaultConectionString);
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
    pattern: "{controller=Home}/{action=Index}");
using (var scope = app.Services.CreateScope ()) {
    await InitializeDatabaseAsync (scope);
}

app.Run ();

Console.WriteLine ("");

void AddServices (WebApplicationBuilder builder) {
    IServiceCollection services = builder.Services;

    services.AddSingleton<IConfiguration> (builder.Configuration);
    services.AddSingleton<IWebsiteConfig, WebsiteConfig> ((services) => new WebsiteConfig (services.GetService<IConfiguration> ()));

    services.AddScoped<IApiRequestClient, ApiRequestClient> (services => new ApiRequestClient (DefaultApiRequestClientFactory.Instance, services.GetService<IWebsiteConfig> ().ApiConfig.ApiUrl));

    services.AddScoped<IPasswordHasher<LoginDetails>, PasswordHasher<LoginDetails>> ();

    AddModelHandlers (services);

    services.AddAuthentication (CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie (options => {
                options.ExpireTimeSpan = TimeSpan.FromMinutes (30);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Login";
            });

    void AddModelHandlers (IServiceCollection services) {
        services.AddScoped<ILoginHandler, LoginHandler> ();
        services.AddScoped<IRegistrationHandler, RegistrationHandler> ();
        services.AddScoped<ICrimeHandler, CrimeHandler> ();
        services.AddScoped<IFactionInfoHandler, FactionInfoHandler> ();
        services.AddScoped<IUserHandler, UserHandler> ();
    }
}

void AddEntityAccessors (WebApplicationBuilder builder) {
    IServiceCollection services = builder.Services;

    services.AddScoped<IUserAccess, UserAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Users;

        return new UserAccess (set, context);
    });

    services.AddScoped<IJobAccess, JobAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<Job> ();

        return new JobAccess (set, context);
    });

    services.AddScoped<ILastActionAccess, LastActionAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<LastAction> ();

        return new LastActionAccess (set, context);
    });

    services.AddScoped<IMarriageAccess, MarriageAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<Marriage> ();

        return new MarriageAccess (set, context);
    });

    services.AddScoped<IPlayerStatesAccess, PlayerStatesAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<PlayerStates> ();

        return new PlayerStatesAccess (set, context);
    });

    services.AddScoped<IStatusAccess, StatusAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<Status> ();

        return new StatusAccess (set, context);
    });

    services.AddScoped<IFactionStubAccess, FactionStubAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<FactionStub> ();

        return new FactionStubAccess (set, context);
    });

    services.AddScoped<ILoginDetailsAccess, LoginDetailsAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<LoginDetails> ();

        return new LoginDetailsAccess (set, context);
    });

    services.AddScoped<IMemberAccess, MemberAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<Member> ();

        return new MemberAccess (set, context);
    });

    services.AddScoped<IFactionCrimeAccess, FactionCrimeAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<FactionCrime> ();

        return new FactionCrimeAccess (set, context);
    });

    services.AddScoped<IFactionInfoAccess, FactionInfoAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<FactionInfo> ();

        return new FactionInfoAccess (set, context);
    });

    services.AddScoped<ICrimeParticipantAccess, CrimeParticipantAccess> (services => {
        var context = services.GetService<DrunkSquadDBContext> ();
        var set = context.Set<CrimeParticipant> ();

        return new CrimeParticipantAccess (set, context);
    });
}


// TODO This needs to be moved into it's own, dedicated app.
async Task InitializeDatabaseAsync (IServiceScope scope) {
    var services = scope.ServiceProvider;

    var config = services.GetRequiredService<IWebsiteConfig> ();

    var factionInfoHandler = services.GetRequiredService<IFactionInfoHandler> ();

    if (factionInfoHandler.GetFactionInfo (config.FactionConfig.ID) is not null) {
        return;
    }

    var factionResponse = await factionInfoHandler.FetchFactionInfoAsync (config.ApiConfig.DefaultKey);

    var info = factionResponse.Content;
    var id = info.FactionID;
    info.FactionID = 0;

    factionInfoHandler.AddFactionInfo (new FactionInfo {
        Basic = info,
        FactionID = id
    });

    var userHandler = services.GetRequiredService<IUserHandler> ();

    foreach (var member in info.Members.Values) {
        var user = await userHandler.FetchUserAsync (config.ApiConfig.DefaultKey, member.MemberID);

        if (user is not null) {
            userHandler.AddUser (user.Content);
        }
    }

    var crimeHandler = services.GetRequiredService<ICrimeHandler> ();

    await crimeHandler.FetchMostRecentCrimesAsync (config.ApiConfig.DefaultKey);
}
