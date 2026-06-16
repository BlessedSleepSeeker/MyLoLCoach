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

	static HttpClient client = new HttpClient();
	public async Task<RiotAccount> GetCurrentAccount(string account_name, string account_tag)
	{
		string riot_api_account_request = RiotEndpoints.BaseCluster + string.Format(RiotEndpoints.AccountEndpoint, account_name, account_tag) + RiotEndpoints.ApiKey;
		HttpResponseMessage http_response = await client.GetAsync(riot_api_account_request);
		string riot_api_response = await http_response.Content.ReadAsStringAsync();
		RiotAccount account = JsonConvert.DeserializeObject<RiotAccount>(riot_api_response);

		return account;
	}
	public async Task<CurrentGameInfo> GetCurrentGame(string puuid)
	{
		string riot_api_account_request = RiotEndpoints.EUWCluster + string.Format(RiotEndpoints.CurrentMatchEndpoint, puuid) + RiotEndpoints.ApiKey;
		logger.LogInformation($"Calling Riot Api at {riot_api_account_request}");
		HttpResponseMessage http_response = await client.GetAsync(riot_api_account_request);
		string riot_api_response_string = await http_response.Content.ReadAsStringAsync();
		logger.LogInformation(riot_api_response_string);

		CurrentGameInfo dict_response = JsonConvert.DeserializeObject<CurrentGameInfo>(riot_api_response_string);

		CurrentGameInfo current_game_info = new()
		{
			// GameId = Convert.ToInt64(GrabbingDataFromJson(dict_response, "gameId")),
			// GameMode = GrabbingDataFromJson(dict_response, "gameMode"),
			// GameType = GrabbingDataFromJson(dict_response, "gameType"),
			// GameStartTime = Convert.ToInt64(GrabbingDataFromJson(dict_response, "gameStartTime")),
			// MapId = Convert.ToInt64(GrabbingDataFromJson(dict_response, "mapId")),
			// GameLength = Convert.ToInt64(GrabbingDataFromJson(dict_response, "gameLength")),
			// PlatformId = GrabbingDataFromJson(dict_response, "platformId")
		};

		// current_game_info.Participants = GrabParticipantsDataFromJson(dict_response);

		return dict_response;
	}
	public ActionResult<string> GetLaneOpponent()
	{
		return "";
	}
	public ActionResult<string> GetLaneOpponentCooldown()
	{
		return "";
	}

	private string GrabbingDataFromJson(Dictionary<string, string>? json, string field)
	{
		string? value = "";
		try
		{
			json?.TryGetValue(field, out value);
		}
		catch (ArgumentNullException ex)
		{
			Console.WriteLine($"Error : field {field} doesn't exist. Exception : {ex}");
		}

		return value ?? "ERROR";
	}

	private List<CurrentGameParticipant> GrabParticipantsDataFromJson(Dictionary<string, string>? json)
	{
		List<CurrentGameParticipant> participants = [];

		string? participants_as_string = "";
		json?.TryGetValue("participants", out participants_as_string);

		
		
		List<Dictionary<string, string>> participants_json = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(participants_as_string);

		return participants;
	}
}