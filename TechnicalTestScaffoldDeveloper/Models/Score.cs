using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTestScaffoldDeveloper.Models
{
    public class Score
    {
        public int Value { get; set; }
        public bool Valid { get; set; }
        public string ErrorType { get; set; }
        public Score()
        {
            this.Valid = true;
        }

        public static Score CalculateScore(List<int> cards)
        {
            // Hopefully this won't return 0 for long....
            Score results = new Score();
            if (CheckCardRange(cards))
            {
                int scoreFromMatching = CountMatching(cards.ToList());
                if (scoreFromMatching > 4)
                {
                    results.Valid = false;
                    results.ErrorType = "Duplicate cards";
                }
                else
                {
                    int scoreFromAddition = CountCombinationsWhichAdd(cards.ToList(), 15);
                    int total = scoreFromAddition + scoreFromMatching;
                    results.Value = total;
                }
            }
            else
            {
                results.Valid = false;
                results.ErrorType = "Card values out of range";
            }

            return results;
        }

        public static bool CheckCardRange(List<int> cards)
        {
            try
            {
                bool valid = true;
                if (!cards.Count().Equals(5))
                {
                    valid = false;
                }
                else
                {
                    foreach (int card in cards)
                    {
                        if (card < 1 || card > 10)
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                return valid;
            }
            catch
            {
                return false;
            }
        }

        public static int CountMatching(List<int> cards)
        {
            int runningScore = 0;
            for (int i = 0; i < cards.Count(); i++)
            {
                for (int j = i + 1; j < cards.Count(); j++)
                {
                    if (cards[i].Equals(cards[j]))
                        runningScore++;
                }
            }
            return runningScore;
        }

        public static int CountCombinationsWhichAdd(List<int> cards, int goalValue)
        {
            return CountCombinationsWhichAdd(0, cards.ToList(), goalValue, 0);
        }

        public static int CountCombinationsWhichAdd(int runningScore, List<int> cards, int requiredTotal, int runningTotal)
        {
            if (cards.Count().Equals(0))
            {
                //Console.WriteLine($"Sum is: {runningTotal}");
                if (runningTotal.Equals(requiredTotal))
                {
                    runningScore++;
                }
            }
            else
            {
                runningScore = CountCombinationsWhichAdd(runningScore, new List<int>(cards.GetRange(1, cards.Count() - 1)), requiredTotal, runningTotal + cards[0]);
                runningScore = CountCombinationsWhichAdd(runningScore, new List<int>(cards.GetRange(1, cards.Count() - 1)), requiredTotal, runningTotal);
            }
            return runningScore;
        }

        // Old methods from non-ASP.net project

        //private static void OutputScore(int score)
        //{
        //    Console.Out.WriteLine(String.Format("Your score is: {0}", score));
        //}

        //private static void OutputCards(List<int> cards)
        //{
        //    // This might be handy for debugging
        //    try
        //    {
        //        for (int i = 0; i < cards.Count(); i++)
        //        {
        //            Console.Out.WriteLine(String.Format("Card {0}: {1}", i, cards[i]));
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        //private static List<int> GetInput()
        //{
        //    // Just use the example to get us started
        //    //return new List<int> { 1, 1, 1, 1, 1 };
        //    //return new List<int> { 3, 3, 3, 2, 10 };
        //    try
        //    {
        //        Console.WriteLine("Please enter 5 card values between 1 and 10.");
        //        Console.WriteLine("Separate values with a comma.");
        //        return FormatStringToIntList(Console.ReadLine());
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public static List<int> FormatStringToIntList(string data)
        //{
        //    try
        //    {
        //        string[] splitData = data.Split(',');
        //        List<int> outputData = new List<int>();
        //        foreach (string card in splitData)
        //        {
        //            outputData.Add(Int32.Parse(card.Trim()));
        //        }
        //        return outputData.ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    bool game = true;

        //    while (game)
        //    {
        //        List<int> cards = GetInput();
        //        OutputCards(cards);
        //        Score score = CalculateScore(cards);
        //        if (score.valid)
        //        {
        //            OutputScore(score.score);
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Invalid cards chosen! {score.errorType}");
        //        }

        //        Console.WriteLine("Press return to play again");
        //        Console.ReadLine();

        //    }
        //}
    }
}

