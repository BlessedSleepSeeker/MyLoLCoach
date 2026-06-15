namespace MyLolCoach.Models;

public class CoachingResult
{
	public string? Puid { get; set; }
	public string? AccountName { get; set; }
	public string? AccountTag { get; set; }
    public string? YourChampion { get; set; }
    public List<string> Opponents { get; set; } = [];
}