namespace Shadowrun.Dice.Factories;

public interface IDieFactory
{
    IDice GenerateDice(int dieCount, bool usingEdge);
}