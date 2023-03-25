namespace Shadowrun.Dice;

using Results;

public class StandardDice : Dice
{
    public StandardDice(ICollection<IDie> dice) 
        : base(dice)
    {
    }

    protected override DieResult Roll(int limit)
    {
        var roll = this.Roll();
        return roll.Hits > limit
            ? roll with { Hits = limit }
            : roll;

    }
}