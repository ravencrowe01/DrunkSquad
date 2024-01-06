using System.Collections.ObjectModel;

namespace DrunkSquad.Models.Common {
    public static class Constants {
        public static readonly string ID = "ID";

        public static readonly string User = "User";
        public static readonly string Property = "Property";
        public static readonly string Faction = "Faction";
        public static readonly string Company = "Company";
        public static readonly string Market = "Market";
        public static readonly string Torn = "Torn";
        public static readonly string Key = "Key";

        public static readonly string DefaultKey = Default + Key;
        public static readonly string Api = "Api";
        public static readonly string ApiUrl = "ApiUrl";
        public static readonly string RequiredApiLevel = "RequiredApiLevel";
        public static readonly string ConnectionStrings = "ConnectionStrings";
        public static readonly string Default = "Default";

        public static readonly string Leader = "Leader";
        public static readonly string CoLeader = "CoLeader";

        public static readonly IReadOnlyDictionary<string, IEnumerable<string>> Sections = new ReadOnlyDictionary<string, IEnumerable<string>> (BuildSectionsDictionary ());

        // TODO Need to populate these
        private static Dictionary<string, IEnumerable<string>> BuildSectionsDictionary () => new Dictionary<string, IEnumerable<string>> {
            { User, new List<string> () },
            { Property, new List<string>() },
            { Faction, new List<string>() },
            { Company, new List<string>() },
            { Market, new List<string>() },
            { Torn, new List<string>() },
            { Key, new List<string>() },
        };
    }
}
