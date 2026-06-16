namespace MyLolCoach.Services;

static class RiotEndpoints
{
	public const string ApiKey = "?api_key=RGAPI-d839ea54-fbf6-41cd-8222-cfe9f0eec9a9";
	public const string BaseCluster = "https://europe.api.riotgames.com";
	public const string AccountEndpoint = "/riot/account/v1/accounts/by-riot-id/{0}/{1}";
	public const string EUWCluster = "https://euw1.api.riotgames.com";
	public const string CurrentMatchEndpoint = "/lol/spectator/v5/active-games/by-summoner/{0}";

}