﻿string? readResult;
bool validEntry = false;
decimal goalWeight = 0m; //Create throw and catch exceptions for wrong entrys
decimal weight = 0m;
decimal weekGoalPercentage = 0m;
// Remember to add 10 (or 20) lbs to any barbell exercise because of the bar weight. Then substract the 10 lbs from every set after the calculations are done
do
{
    Console.WriteLine("\nAre you entering the 5, 3, or 1 rep goal, in your Wendler's 5-3-1 routine?");
    readResult = Console.ReadLine().Trim().ToLower();
    if (readResult != null)
    {
        if (readResult == "5")
        {
            validEntry = true;
            weekGoalPercentage = 0.85m;
        }
        else if (readResult == "3")
        {
            validEntry = true;
            weekGoalPercentage = 0.9m;
        }
        else if (readResult == "1")
        {
            validEntry = true;
            weekGoalPercentage = 0.95m;
        }
        else
        {
            Console.WriteLine("Please enter \"5\", \"3\", or \"1\".");
        }
    }
} while ((validEntry == false));

do
{
    Console.WriteLine("\nEnter the goal weight.");
    readResult = Console.ReadLine().Trim().ToLower();
    if (readResult != null)
    {
        validEntry = decimal.TryParse(readResult, out goalWeight);
        if ((validEntry == false) || (goalWeight%2.5m != 0))
        {
            Console.WriteLine("Please enter a number divisible by 2.5");
        }
    }
} while ((validEntry == false) || (goalWeight%2.5m != 0));

decimal[] sets = {0m, 0m, 0m};

Console.WriteLine("\nWeek 1, 5 reps\n");
decimal[] setsWeekOne = { 0.65m, 0.75m, 0.85m };
sets = setsWeekOne;
CalculateSets();
Console.WriteLine("\nWeek 2, 3 reps\n");
decimal[] setsWeekTwo = { 0.7m, 0.8m, 0.9m };
sets = setsWeekTwo;
CalculateSets();
Console.WriteLine("\nWeek 3, 5-3-1\n");
decimal[] setsWeekThree = { 0.75m, 0.85m, 0.95m };
sets = setsWeekThree;
CalculateSets();
Console.WriteLine("\nDeload Week\n");
decimal[] setsWeekFour = { 0.4m, 0.5m, 0.6m };
sets = setsWeekFour;
CalculateSets();

//Ask the user if they want to see next months or last months numbers as well with a do while statement.
//Consider other calculators like one that can show you what your real world bench press would be. Or have it show you the full weight being lifted and not just the divided by 2 dumbbells weights.
//Have it ask the user if its a machine lift that uses the full weight number or a barbell that divides it by 2.
//Maybe make it so the user can set a goal weight and planned progression so the program can calculate how many more months until they reach the goal.
void CalculateSets()
{
decimal oneRepMax = goalWeight / weekGoalPercentage;
    foreach (decimal set in sets)
    {
        weight = (oneRepMax * set);
        Console.Write($"{weight:N2}");
        RoundedWeight();
        RoundedWeightTwo();
    }
}

void RoundedWeight() //Rounds the weight in each set to the nearest number divisible by 5 to reflect actual available gym weights
{
    decimal rweight = Math.Round(weight, 0);
    decimal weightUp = rweight;
    decimal weightDown = rweight;
    bool zero = false;

    if (rweight%2.5m == 0m)
    {
        zero = true;
        Console.Write($"\t{rweight}");
    }
    else
    {
        while (zero == false)
        {
            weightUp++;
            weightDown--;
            //if (weightUp == 107m) break;
            if ((weightUp%5 == 0m) || (weightDown%5 == 0m))
                {
                    zero = true;
                    if (weightUp%5m == 0m)
                    {
                        Console.Write($"\t{weightUp}");
                    }
                    else
                    {
                        Console.Write($"\t{weightDown}");
                    }
                }
        }
    }
}

void RoundedWeightTwo() //Rounds the weight in each set to the nearest number divisible by 2.5 to reflect actual available gym weights
{
    decimal rweight = Math.Round(weight, 1);
    decimal weightUp = rweight;
    decimal weightDown = rweight;
    bool zero = false;

    if (rweight%2.5m == 0)
    {
        zero = true;
        Console.Write($"\t{rweight}\n");
    }
    else
    {
        while (zero == false)
        {
            weightUp = weightUp + 0.1m;
            weightDown = weightDown - 0.1m;
            //if (weightUp > 95.2m) break;
            if ((weightUp%2.5m == 0m) || (weightDown%2.5m == 0m))
                {
                    zero = true;
                    if (weightUp%2.5m == 0m)
                    {
                        Console.WriteLine($"\t{weightUp}");
                    }
                    else
                    {
                        Console.WriteLine($"\t{weightDown}");
                    }
                }
        }
    }
}