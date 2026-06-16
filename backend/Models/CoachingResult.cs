namespace MyLolCoach.Models;

public class CoachingResult
{
	public string? Puuid { get; set; }
	public string? AccountName { get; set; }
	public string? AccountTag { get; set; }
	public CurrentGameInfo? CurrentGame { get; set; }
    public string? YourChampion { get; set; }
    public List<string> Opponents { get; set; } = [];
}