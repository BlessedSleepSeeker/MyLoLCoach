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
    
		[HttpGet]
    	public async Task<ActionResult<CoachingResult>> GetCoaching()
    	{
    	    return _coaching_service.GetCoachingAsync();
    	}
    }
}
