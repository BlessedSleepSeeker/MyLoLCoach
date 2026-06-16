using Microsoft.AspNetCore.Mvc;
using MyLolCoach.Models;
using MyLolCoach.Services;

public interface IRiotService
{
	Task<RiotAccount> GetCurrentAccount(string account_name, string account_tag);
	Task<CurrentGameInfo> GetCurrentGame(string puuid);
	ActionResult<string> GetLaneOpponent();
	ActionResult<string> GetLaneOpponentCooldown();
}