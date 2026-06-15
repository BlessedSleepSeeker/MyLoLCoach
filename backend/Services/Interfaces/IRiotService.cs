using Microsoft.AspNetCore.Mvc;
using MyLolCoach.Models;

public interface IRiotService
{
	Task<string> GetCurrentAccount(string account_name, string account_tag);
	ActionResult<string> GetCurrentGame();
	ActionResult<string> GetLaneOpponent();
	ActionResult<string> GetLaneOpponentCooldown();
}