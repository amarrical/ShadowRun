namespace Shadowrun.Dice.Factories;

public class DieFactory : IDieFactory
{
    public IDice GenerateDice(int dieCount, bool usingEdge)
    {
        var dice = Enumerable.Range(1, dieCount).Select(i => usingEdge ? (IDie)new EdgeDie() : new Die()).ToList();
        return usingEdge
            ? new EdgeDice(dice)
            : new StandardDice(dice);
    }
}