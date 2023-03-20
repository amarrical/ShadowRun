namespace Shadowrun.tests.Stubs;

public class Sequence
{
    private List<int> sequence = new();

    public void SetSequence(params int[] init) => this.sequence = init.ToList();


    public int Next()
    {
        if (!sequence.Any())
            return 0;

        var roll = sequence.First();
        sequence.Remove(roll);
        return roll;
    }
}