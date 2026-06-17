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
	public async Task<Champion> GetLaneOpponent(string champion_name)
	{
		string riot_api_champion_request = RiotEndpoints.BuildChampionDataURL(champion_name);
		logger.LogInformation($"Calling Riot Api at {riot_api_champion_request}");

		HttpResponseMessage http_response = await client.GetAsync(riot_api_champion_request);
		string riot_api_response_string = await http_response.Content.ReadAsStringAsync();
		// Cleaning up the response string to trick the JsonConvert into working with our data structure.
		string to_remove = $"\"data\":{{\"{champion_name}\":{{";
		riot_api_response_string = riot_api_response_string.Remove(riot_api_response_string.IndexOf(to_remove), to_remove.Length);
		riot_api_response_string = riot_api_response_string[..^2];
		logger.LogInformation(riot_api_response_string);

		Champion champion = JsonConvert.DeserializeObject<Champion>(riot_api_response_string);

		return champion;
	}
	public ActionResult<List<List<int>>> GetLaneOpponentCooldown(Champion champion)
	{
		List<List<int>> cooldown_list = [];

		return cooldown_list;
	}
}