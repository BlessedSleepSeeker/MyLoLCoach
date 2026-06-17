using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyLolCoach.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MyLolCoach.Services;
public class RiotService : IRiotService
{
	private ILogger<RiotService> logger;

	public RiotService(ILogger<RiotService> _logger)
	{
		logger = _logger;
	}

	private static HttpClient client = new HttpClient();
	public async Task<RiotAccount> GetCurrentAccount(string account_name, string account_tag)
	{
		string riot_api_account_request = RiotEndpoints.BuildAccountURL(account_name, account_tag);
		HttpResponseMessage http_response = await client.GetAsync(riot_api_account_request);
		string riot_api_response = await http_response.Content.ReadAsStringAsync();
		RiotAccount account = JsonConvert.DeserializeObject<RiotAccount>(riot_api_response);

		return account;
	}

	// Get the data on the current played game by the account specified. Currently locked to EUW server.
	public async Task<CurrentGameInfo> GetCurrentGame(string puuid)
	{
		string riot_api_account_request = RiotEndpoints.BuildCurrentMatchURL(puuid);
		logger.LogInformation($"Calling Riot Api at {riot_api_account_request}");

		HttpResponseMessage http_response = await client.GetAsync(riot_api_account_request);
		string riot_api_response_string = await http_response.Content.ReadAsStringAsync();
		logger.LogInformation(riot_api_response_string);

		CurrentGameInfo current_game_info = JsonConvert.DeserializeObject<CurrentGameInfo>(riot_api_response_string);

		return current_game_info;
	}
	public ActionResult<string> GetLaneOpponent()
	{
		return "";
	}
	public ActionResult<string> GetLaneOpponentCooldown()
	{
		return "";
	}
}