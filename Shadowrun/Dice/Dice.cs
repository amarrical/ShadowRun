namespace Shadowrun.Dice;

using Results;

public abstract class Dice : IDice
{
    protected Dice(ICollection<IDie> dice)
    {
        this.TheDice = dice;
    }

    protected ICollection<IDie> TheDice { get; set; }


    public virtual TestResult Test(int limit, Threshold threshold)
    {
        var roll = this.Roll(limit);
        var glitch = roll.Ones >= (this.TheDice.Count + 1) / 2;
        var netHits = roll.Hits - (int)threshold;
        var success = netHits >= 0;
        var overallResult = new UnevaluatedResult(success, glitch).ResultType();
        return new TestResult(netHits, overallResult);
    }

    protected abstract DieResult Roll(int limit);

    protected DieResult Roll() => this.TheDice.Select(d => d.Roll()).Tally();
}