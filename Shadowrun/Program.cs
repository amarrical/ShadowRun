// See https://aka.ms/new-console-template for more information

using Shadowrun;
using Shadowrun.Dice.Factories;

var prompter = new ResponsePrompter();

while (true)
{
    var dieCount = prompter.getInt("Number of Dice in pool?");
    var threshold = prompter.GetThreshold("Threshold of test?");
    var limit = prompter.getInt("Applicable limit?");
    var usingEdge = prompter.GetBool("Using edge?");
    var dice = new DieFactory().GenerateDice(dieCount, usingEdge);
    var result = dice.Test(limit, threshold);
    Console.WriteLine($"Result: {result.ResultType} with net hits: {result.NetHits}");
}