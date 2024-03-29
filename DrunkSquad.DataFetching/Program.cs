﻿using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Faction;
using DrunkSquad.Framework.Logic.Faction.Crimes;
using DrunkSquad.Framework.Logic.Faction.Info;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Logic.Faction;
using DrunkSquad.Logic.Faction.Crimes;
using DrunkSquad.Logic.Faction.Info;
using DrunkSquad.Logic.Users;
using DrunkSquad.Models.Config;
using TornApi.Net.Models.Key;
using TornApi.Net.REST;

#nullable disable
namespace DrunkSquad.DateFetching {
    internal class Program {
        private static CancellationTokenSource _tokenSource;
        private static CancellationToken _cancelToken;

        private static Config _config;

        private static IApiRequestClient _client;

        private static FetchingContext _context;

        private static IFactionInfoAccess _factionInfoAccess;
        private static IProfileAccess _profileAccess;
        private static IPositionAccess _positionAccess;
        private static IMemberAccess _memberAccess;
        private static IFactionCrimeAccess _crimeAccess;
        private static ICrimeExperienceEntryAccess _crimeExperienceAccess;

        private static IFactionInfoHandler _factionInfoHandler;
        private static IProfileHandler _profileHandler;
        private static IPositionHandler _positionHandler;
        private static IMemberHandler _memberHandler;
        private static ICrimeHandler _crimeHandler;
        private static ICrimeExperienceHandler _crimeExperienceHandler;

        private static Task _factionInfoFetchTask;

        internal static void Main (string [] args) {
            Setup (args);

            Start ();

            Console.ReadKey ();
        }

        private static void Start () {
            _factionInfoFetchTask = StartFactionInfoFetcherAsync ();

            Task.Run (() => StartCrimeFetcherAsync ());
        }

        private static void Setup (string [] args) {
            _config = new Config {
                Api = new ApiConfig {
                    ApiUrl = @"https://api.torn.com/",
                    DefaultConectionString = args [1],
                    DefaultKey = args [0],
                    RequiredAccessLevel = AccessLevel.LimitedAccess
                },
                Faction = new FactionConfig {
                    ID = int.Parse (args [2])
                }
            };

            _tokenSource = new CancellationTokenSource ();
            _cancelToken = _tokenSource.Token;

            _client = new ApiRequestClient (DefaultApiRequestClientFactory.Instance, _config.Api.ApiUrl);

            _context = new FetchingContext (args [1]);

            _factionInfoAccess = new FactionInfoAccess (_context.Factioninfo, _context);
            _profileAccess = new ProfileAccess (_context.Profiles, _context);
            _positionAccess = new PositionAccess (_context.Positions, _context);
            _memberAccess = new MemberAccess (_context.Members, _context);
            _crimeAccess = new FactionCrimeAccess (_context.Crimes, _context);
            _crimeExperienceAccess = new CrimeExperienceEntryAccess (_context.CrimeExperience, _context);

            _factionInfoHandler = new FactionInfoHandler (_client, _config, _factionInfoAccess);
            _profileHandler = new ProfileHandler (_client, _config, _profileAccess);
            _positionHandler = new PositionHandler(_client, _config, _positionAccess);
            _memberHandler = new MemberHandler (_client, _config, _memberAccess);
            _crimeHandler = new CrimeHandler (_client, _config, _crimeAccess, _profileAccess);
            _crimeExperienceHandler = new CrimeExperienceHandler (_client, _config, _crimeExperienceAccess, _memberAccess);
        }

        private static async Task StartFactionInfoFetcherAsync () {
            var fetcher = new FactionInfoFetcher (_factionInfoHandler, _profileHandler, _positionHandler, _crimeExperienceHandler, _cancelToken);

            await fetcher.StartAsync ().ConfigureAwait (false);
        }

        private static async Task StartCrimeFetcherAsync () {
            _factionInfoFetchTask.Wait (_cancelToken);

            var fetcher = new CrimeFetcher (_crimeHandler, _cancelToken);

            Console.WriteLine ("Starting crime fetcher...");

            await fetcher.StartAsync ().ConfigureAwait (false);

            Console.WriteLine ("Crime fetcher started.");
        }

        private class Config : IWebsiteConfig {
            public IApiConfig Api { get; set; }

            public IFactionConfig Faction { get; set; }
        }

        private class ApiConfig : IApiConfig {
            public string DefaultKey { get; set; }

            public string ApiUrl { get; set; }

            public string DefaultConectionString { get; set; }

            public AccessLevel RequiredAccessLevel { get; set; }

            public string ConnectionString { get; set; }

            public string GetConnectionString (string name = "Default") => ConnectionString;
        }

        private class FactionConfig : IFactionConfig {
            public int CoLeader { get; set; }

            public int ID { get; set; }

            public int Leader { get; set; }
        }
    }
}