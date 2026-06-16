namespace MyLolCoach.Models;

public class BannedChampion
{
	
}

public class CurrentGameParticipant
{
	// Account Puuid
	public string? Puuid { get; set; }
	public long ChampionId { get; set; }
	// 100 = blue, 200 = red, more = arena
	public long TeamId { get; set; }
	// Summoner Spell 1
	public string? Spell1Id { get; set; }
	// Summoner Spell 2
	public string? Spell2Id { get; set; }
}

public class CurrentGameInfo
{
	public long GameId { get; set; }
	public long MapId { get; set; }
	public string? GameMode { get; set; }
	public string? GameType { get; set; }
	public long GameStartTime { get; set; }
	public long GameLength { get; set; }
	public string? PlatformId { get; set; }
	public List<CurrentGameParticipant> Participants { get; set; } = [];
}

public class RiotAccount
{
	public string? Puuid { get; set; }
	public string? GameName { get; set; }
	public string? TagLine { get; set; }
}