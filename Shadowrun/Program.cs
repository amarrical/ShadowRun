// See https://aka.ms/new-console-template for more information
using Shadowrun;
using Shadowrun.SuccessCheckers;

var prompter = new ResponsePrompter();

while (true)
{
    var dieCount = prompter.getInt("Number of Dice in pool?");
    var threshold = prompter.GetThreshold("Threshold of test?");
    var usingEdge = prompter.GetBool("Using edge?");
    var result = new ThresholdChecker(threshold).CheckSuccess(dieCount, usingEdge);
    Console.WriteLine($"Result: {result.ResultType} with net hits: {result.NetHits}");
}