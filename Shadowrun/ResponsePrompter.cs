namespace Shadowrun;

public class ResponsePrompter
{
    private string[] positiveResponses = { "y", "yes", "Y", "Yes", "YES" };
    private string[] negativeResponses = { "n", "no", "N", "No", "NO" };

    public int getInt(string prompt)
    {
        var response = this.Prompt(prompt);
        return int.TryParse(response, out var result)
            ? result
            : this.getInt(prompt);
    }

    public bool GetBool(string prompt)
    {
        var response = this.Prompt(prompt);
        var parsed = bool.TryParse(response, out var result);
        if (this.positiveResponses.Contains(response))
            return true;

        if (this.negativeResponses.Contains(response))
            return false;

        return parsed
            ? result
            : this.GetBool(prompt);
    }

    public Threshold GetThreshold(string prompt)
    {
        var response = this.Prompt(prompt);
        return Enum.TryParse(response, out Threshold result)
            ? result
            : this.GetThreshold(prompt);
    }

    private string? Prompt(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine();
    }
}