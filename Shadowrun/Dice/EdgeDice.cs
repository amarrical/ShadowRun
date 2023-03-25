namespace Shadowrun.Dice;

using Results;

public class EdgeDice : Dice
{
    public EdgeDice(ICollection<IDie> dice) 
        : base(dice)
    {
    }

    protected override DieResult Roll(int limit) => this.Roll();
}