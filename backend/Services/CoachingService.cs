using Microsoft.AspNetCore.Mvc;
using MyLolCoach.Models;

namespace MyLolCoach.Services;
public class CoachingService : ICoachingService
{
	private readonly IRiotService _riot_service;

	public CoachingService(IRiotService riot_service)
	{
		_riot_service = riot_service;
	} 
	public async Task<ActionResult<CoachingResult>> GetCoachingAsync(string account_name, string account_tag)
	{
		CoachingResult result = new()
		{
			Puuid = "test_puid",
			AccountName = account_name,
			AccountTag = account_tag,
			YourChampion = "Void",
			Opponents = ["Testo", "Testu"]
		};
		RiotAccount account = await _riot_service.GetCurrentAccount(account_name, account_tag);

		result.Puuid = account.Puuid;
		result.AccountName = account.GameName;
		result.AccountTag = account.TagLine;

		result.CurrentGame = await _riot_service.GetCurrentGame(result.Puuid);

		return result;
	}
}