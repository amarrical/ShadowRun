using Shadowrun.Dice;

public interface IDieFactory
{
    ICollection<IDie> GenerateDice(int dieCount, bool usingEdge);
}