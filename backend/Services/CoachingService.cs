using Microsoft.AspNetCore.Mvc;
using MyLolCoach.Models;

namespace MyLolCoach.Services;
public class CoachingService : ICoachingService
{
	public ActionResult<CoachingResult> GetCoachingAsync()
	{
		CoachingResult result = new()
		{
			YourChampion = "Test",
			Opponents = ["Testo", "Testu"]
		};
		return result;
	}
}