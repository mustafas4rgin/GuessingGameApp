using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class Game : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string MetaScore { get; set; } = string.Empty;
    public string OriginalPlatform { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Release { get; set; } = string.Empty;
    public string Developer { get; set; } = string.Empty;
}