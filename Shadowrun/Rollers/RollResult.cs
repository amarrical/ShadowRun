namespace Shadowrun.Rollers;

public record RollResult(int NetHits, RollResult.Result OverallResult)
{
    public Result OverallResult { get; } = OverallResult;

    public enum Result
    {
        Success,
        Failure,
        Glitch,
        CriticalGlitch
    }
}