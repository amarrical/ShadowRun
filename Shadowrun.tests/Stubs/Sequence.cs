namespace Shadowrun.tests.Stubs;

public class Sequence
{
    private List<int> sequence = new();

    public void SetSequence(params int[] init) => this.sequence = init.ToList();


    public int Next()
    {
        if (!this.sequence.Any())
            return 0;

        var roll = this.sequence.First();
        this.sequence.Remove(roll);
        return roll;
    }
}