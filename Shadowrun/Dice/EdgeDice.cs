namespace Shadowrun.Dice;

using Results;

public class EdgeDice : StandardDice
{
    public EdgeDice(ICollection<IDie> dice) 
        : base(dice)
    {
    }

    public override DieResult Roll(int limit)
    {
        return base.Roll();
    }
}