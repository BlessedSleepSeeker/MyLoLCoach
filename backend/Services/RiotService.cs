using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyLolCoach.Models;

namespace MyLolCoach.Services;
public class RiotService : IRiotService
{
	static HttpClient client = new HttpClient();
	public async Task<string> GetCurrentAccount(string account_name, string account_tag)
	{
		string riot_api_account_request = RiotEndpoints.BaseCluster + string.Format(RiotEndpoints.AccountEndpoint, account_name, account_tag) + RiotEndpoints.ApiKey;
		HttpResponseMessage http_response = await client.GetAsync(riot_api_account_request);
		var dict_response = JsonConvert.DeserializeObject<Dictionary<string, string>>(await http_response.Content.ReadAsStringAsync());

		string? puuid = "";
		var result = dict_response?.TryGetValue("puuid", out puuid);

		return puuid ?? "ERROR";
	}
	public ActionResult<string> GetCurrentGame()
	{
		return "";
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