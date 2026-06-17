namespace MyLolCoach.Services;

static class RiotEndpoints
{
	public const string ApiKey = "?api_key=RGAPI-1f2308f9-2ef6-4b4e-bf08-9de06e2c7642";
	public const string latest_patch_version = "16.12.1";
	public const string localization = "en_US";
	public const string BaseCluster = "https://europe.api.riotgames.com";
	public const string AccountEndpoint = "/riot/account/v1/accounts/by-riot-id/{0}/{1}";
	public const string EUWCluster = "https://euw1.api.riotgames.com";
	public const string CurrentMatchEndpoint = "/lol/spectator/v5/active-games/by-summoner/{0}";
	public const string DataDragonCluster = "https://ddragon.leagueoflegends.com/cdn";
	// Used to get the latest patch version
	public const string DataDragonVersions = "https://ddragon.leagueoflegends.com/api/versions.json";
	// Used to link champions ids to name.
	// {0} is patch number formated as "16.12.1".
	// {1} is language formated as "en_US".
	public const string ChampionsEndpoint = "/{0}/data/{1}/champion.json";
	// Used to get champions data from name.
	// {0} is patch number formated as "16.12.1".
	// {1} is language formated as "en_US".
	// {2} is champion name formated as "Bard".
	public const string ChampionDataEndpoint = "/{0}/data/{1}/champion/{2}.json";

	public static string BuildAccountURL(string account_name, string account_tag)
	{
		return BaseCluster + string.Format(AccountEndpoint, account_name, account_tag) + ApiKey;
	}

	public static string BuildCurrentMatchURL(string puuid)
	{
		return EUWCluster + string.Format(CurrentMatchEndpoint, puuid) + ApiKey;
	}
	public static string BuildChampionDataURL(string champion_name, string current_patch = latest_patch_version, string language = localization)
	{
		return DataDragonCluster + string.Format(ChampionDataEndpoint, current_patch, language, champion_name) + ApiKey;
	}
}