using Microsoft.AspNetCore.Mvc;
using MyLolCoach.Models;

namespace MyLolCoach.Services;
public class RiotService : IRiotService
{
	public ActionResult<string> GetCurrentAccount(string account_name)
	{
		return "";
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