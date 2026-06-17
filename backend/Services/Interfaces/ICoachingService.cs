using Microsoft.AspNetCore.Mvc;
using MyLolCoach.Models;

public interface ICoachingService
{
	Task<ActionResult<CoachingResult>> GetCoachingAsync(string account_name, string account_tag);
	Task<ActionResult<CoachingResult>> GetMatchupAsync(string champion_name);
}