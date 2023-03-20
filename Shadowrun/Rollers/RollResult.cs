


public class RollResult
{
    public RollResult(int netHits, Result overallResult)
    {
        this.NetHits = netHits;
        this.OverallResult = overallResult;
    }

    public Result OverallResult { get; set; }

    public int NetHits { get; }
    
    public enum Result
    {
        Success,
        Failure,
        Glitch,
        CriticalGlitch
    }
}