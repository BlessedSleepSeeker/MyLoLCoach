using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLolCoach.Models;

namespace MyLolCoach.Controllers
{
    [Route("coach_me")]
    [ApiController]
    public class CoachController : ControllerBase
    {
		private readonly ICoachingService _coaching_service;

		public CoachController(ICoachingService coaching_service)
		{
			_coaching_service = coaching_service;
		}
    
		[HttpGet("{account_name}/{account_tag}")]
    	public async Task<ActionResult<CoachingResult>> GetCoaching(string account_name, string account_tag)
    	{
    	    return await _coaching_service.GetCoachingAsync(account_name, account_tag);
    	}

		[HttpGet]
    	public ActionResult<CoachingResult> GetCoaching2()
    	{
    	    CoachingResult result = new()
			{
				Puid = "test_puid",
				YourChampion = "Test",
				Opponents = ["Testo", "Testu"]
			};

			return result;
    	}
    }
}
