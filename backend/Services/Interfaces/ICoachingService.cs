using Microsoft.AspNetCore.Mvc;
using MyLolCoach.Models;

public interface ICoachingService
{
	ActionResult<CoachingResult> GetCoachingAsync();
}