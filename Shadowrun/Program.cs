// See https://aka.ms/new-console-template for more information

using Shadowrun;
using Shadowrun.Rollers;

var prompter = new ResponsePrompter();

while (true)
{
    var dice = prompter.getInt("Number of Dice in pool?");
    var threshold = prompter.getInt("Threshold of test?");
    var usingEdge = prompter.GetBool("Using edge?");
    var result = new Roller().CheckSuccess(dice, threshold, usingEdge);
    Console.WriteLine($"Result: {result.OverallResult} with net hits: {result.NetHits}");
}