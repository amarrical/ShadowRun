using Shadowrun;

public interface IDieFactory
{
    ICollection<IDie> GenerateDice(int dieCount, bool usingEdge);
}