namespace Shadowrun.Dice;

using Results;

public class StandardDice : IDice
{
    public StandardDice(ICollection<IDie> dice)
    {
        this.Dice = dice;
    }

    protected ICollection<IDie> Dice { get; }

    public virtual TestResult Test(int limit, Threshold threshold)
    {
        var roll = this.Roll(limit);
        var glitch = roll.Ones >= (this.Dice.Count + 1) / 2;
        var netHits = roll.Hits - (int)threshold;
        var success = netHits >= 0;
        var overallResult = new UnevaluatedResult(success, glitch).ResultType();
        return new TestResult(netHits, overallResult);
    }

    public virtual DieResult Roll(int limit)
    {
        var roll = this.Roll();
        return roll.Hits > limit
            ? roll with { Hits = limit }
            : roll;
    }

    public DieResult Roll() => this.Dice.Select(d => d.Roll()).Tally();
}