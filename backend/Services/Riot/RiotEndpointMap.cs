namespace MyLolCoach.Models;

public class RiotAccount
{
	// Encrypted PUUID. Exact length of 78 characters. 
	public string? Puuid { get; set; }
	// In game Name. E.G. "Greninja Tabi".
	// This field may be excluded from the response if the account doesn't have a gameName. 
	public string? GameName { get; set; }
	// In game Tag. E.G. "#EUW"
	// This field may be excluded from the response if the account doesn't have a tagLine. 
	public string? TagLine { get; set; }
}

public class CurrentGameInfo
{
	// The ID of the game 
	public long GameId { get; set; }
	// The game type 
	public string? GameType { get; set; }
	// The game start time represented in epoch milliseconds 
	public long GameStartTime { get; set; }
	// The ID of the map 
	public long MapId { get; set; }
	// The amount of time in seconds that has passed since the game started 
	public long GameLength { get; set; }
	// The ID of the platform on which the game is being played 
	public string? PlatformId { get; set; }
	// The game mode 
	public string? GameMode { get; set; }
	// Banned champion information 
	public List<BannedChampion> BannedChampions { get; set; } = [];
	// The queue type (queue types are documented on the Game Constants page) 
	public long GameQueueConfig { get; set; }
	// The participant information 
	public List<CurrentGameParticipant> Participants { get; set; } = [];
}

public class CurrentGameParticipant
{
	// The ID of the champion played by this participant 
	public long ChampionId { get; set; }
	// Perks/Runes Reforged Information 
	public Perks? Perks { get; set; }
	// The ID of the profile icon used by this participant 
	public long ProfileIconId { get; set; }
	// Flag indicating whether or not this participant is a bot.
	public bool Bot { get; set; }
	// The team ID of this participant, indicating the participant's team 
	// 100 = blue, 200 = red, more = arena
	public long TeamId { get; set; }
	// The encrypted puuid of this participant. null when the player is anonym.
	public string? Puuid { get; set; }
	// The ID of the first summoner spell used by this participant 
	public string? Spell1Id { get; set; }
	// The ID of the second summoner spell used by this participant 
	public string? Spell2Id { get; set; }
	// List of Game Customizations 
	public List<GameCustomizationObject> GameCustomizationObjects { get; set; } = [];
}

public class Perks
{
	// IDs of the perks/runes assigned. 
	public List<long> PerkIds { get; set; } = [];
	// Primary runes path 
	public long PerkStyle { get; set; }
	// Secondary runes path 
	public long PerkSubStyle { get; set; }
}

public class GameCustomizationObject
{
	// Category identifier for Game Customization 
	public string? Category { get; set; }
	// Game Customization content 
	public string? Content { get; set; }
}

public class BannedChampion
{
	// The turn during which the champion was banned 
	public int PickTurn { get; set; }
	// The ID of the banned champion 
	public long ChampionId { get; set; }
	// The ID of the team that banned the champion 
	public long TeamId { get; set; }
}

public class Champion
{
	public string? Type { get; set; }
	// This time, it's the champion's name
	public string? Id { get; set; }
	// Equivalent to ChampionId
	public long Key { get; set; }
	public List<String> AllyTips { get; set; } = [];
	public List<String> EnemyTips { get; set; } = [];
	public List<Spell> Spells { get; set; } = [];
}

public class Spell
{
	// The spell name formated as "{ChampionId}{KeyboardLetter}", E.G. "AatroxQ".
	public string? Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public string? Tooltip { get; set; }
	public List<float> Cooldown { get; set; } = [];
}