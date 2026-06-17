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
			RiotAccount = await _riot_service.GetCurrentAccount(account_name, account_tag),
		};

		result.CurrentGame = await _riot_service.GetCurrentGame(result.RiotAccount?.Puuid);

		return result;
	}

	public async Task<ActionResult<CoachingResult>> GetMatchupAsync(string champion_name)
	{
		CoachingResult result = new()
		{
			Matchup = await _riot_service.GetLaneOpponent(champion_name)
		};

		return result;
	}
}