namespace Shadowrun.Results;

using Shadowrun;

public record DieResult(int Hits, int Ones, int DiceRolled)
{
    public static DieResult operator +(DieResult d1, DieResult d2)
    {
        return new DieResult(d1.Hits + d2.Hits, d1.Ones + d2.Ones, d1.DiceRolled + d2.DiceRolled);
    }

    public bool Success(Threshold threshold) => this.Hits >= (int)threshold;

    public bool Glitch() => this.Ones >= (this.DiceRolled + 1) / 2; // Adding 1 so odd die counts calculate correctly

    public RollResult Result(Threshold threshold)
    {
        return new RollResult(this.NetHits(threshold), this.ResultType(threshold));
    }

    private int NetHits(Threshold threshold) => this.Success(threshold) ? this.Hits - (int)threshold : 0;

    private ResultType ResultType(Threshold threshold)
    {
        return this.Glitch() switch
        {
            true => this.Success(threshold) switch
            {
                true => Results.ResultType.Glitch,
                false => Results.ResultType.CriticalGlitch
            },
            false => this.Success(threshold) switch
            {
                true => Results.ResultType.Success,
                false => Results.ResultType.Failure
            }
        };
    }
}