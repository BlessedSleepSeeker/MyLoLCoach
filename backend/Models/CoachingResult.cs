namespace MyLolCoach.Models;

public class CoachingResult
{
	public RiotAccount? RiotAccount { get; set; }
	public CurrentGameInfo? CurrentGame { get; set; }
	public Champion? Matchup { get; set; }
}