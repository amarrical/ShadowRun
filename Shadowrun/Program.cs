// See https://aka.ms/new-console-template for more information

while (true)
{
    var dice = GetIntResponse("Number of Dice in pool?");
    var threshold = GetIntResponse("Threshold of test?");
    var usingEdge = GetBoolResponse("Using edge?");
    var result = new Roller().CheckSuccess(dice, threshold, usingEdge);
    Console.WriteLine($"Result: {result.OverallResult} with net hits: {result.NetHits}");
}



int GetIntResponse(string prompt)
{
    Console.WriteLine(prompt);
    var response = Console.ReadLine();
    return int.TryParse(response, out var result) 
        ? result 
        : GetIntResponse(prompt);
}

bool GetBoolResponse(string prompt)
{
    Console.WriteLine(prompt);
    var response = Console.ReadLine();
    var parsed = bool.TryParse(response, out var result);
    if (new[] { "y", "yes", "Y", "Yes", "YES" }.Contains(response))
    {
        result = true;
        parsed = true;
    }

    if (new[] { "n", "no", "N", "No", "NO" }.Contains(response))
    {
        result = false;
        parsed = true;
    }

    return parsed
        ? result
        : GetBoolResponse(prompt);
}