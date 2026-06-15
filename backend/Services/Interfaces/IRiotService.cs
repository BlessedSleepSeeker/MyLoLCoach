using Microsoft.AspNetCore.Mvc;
using MyLolCoach.Models;

public interface IRiotService
{
	ActionResult<string> GetCurrentAccount(string account_name);
	ActionResult<string> GetCurrentGame();
	ActionResult<string> GetLaneOpponent();
	ActionResult<string> GetLaneOpponentCooldown();
}