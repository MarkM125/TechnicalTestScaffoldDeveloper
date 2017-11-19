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

        public static int CountCombinationsWhichAdd(List<int> cards, int goalValue, bool forceUseAllCards = false)
        {
            return CountCombinationsWhichAdd(0, cards.ToList(), goalValue, 0, forceUseAllCards);
        }

        public static int CountCombinationsWhichAdd(int runningScore, List<int> cards, int requiredTotal, int runningTotal, bool forceUseAllCards)
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
                runningScore = CountCombinationsWhichAdd(runningScore, new List<int>(cards.GetRange(1, cards.Count() - 1)), requiredTotal, runningTotal + cards[0], forceUseAllCards);
                if (!forceUseAllCards)
                {
                    runningScore = CountCombinationsWhichAdd(runningScore, new List<int>(cards.GetRange(1, cards.Count() - 1)), requiredTotal, runningTotal, forceUseAllCards);
                }
            }
            return runningScore;
        }

        // Quick methods for calculating stats with cards, should probably be done by direct recursion (but hey, it's Sunday)
        public static int CountSumsThatEqualValues(int requiredScore = 15)
        {
            List<int> cards = new List<int>();
            int countScoreHits = 0;
            for (int count1 = 1; count1 < 11; count1++)
            {
                for (int count2 = 1; count2 <= count1; count2++)
                {
                    for (int count3 = 1; count3 <= count2; count3++)
                    {
                        for (int count4 = 1; count4 <= count3; count4++)
                        {
                            for (int count5 = 1; count5 <= count4; count5++)
                            {
                                cards = new List<int>() { count1, count2, count3, count4, count5 };
                                if (CountCombinationsWhichAdd(cards, requiredScore,true) > 0)
                                {
                                    countScoreHits++;
                                }
                            }
                        }
                    }
                }
            }
            return countScoreHits;
        }

        public static List<int> FindScore(int requiredScore = 0)
        {
            Score score = new Score();
            List<int> cards = new List<int>();
            for (int count1 = 1; count1 < 11; count1++)
            {
                for (int count2 = 1; count2 < 11; count2++)
                {
                    for (int count3 = 1; count3 < 11; count3++)
                    {
                        for (int count4 = 1; count4 < 11; count4++)
                        {
                            for (int count5 = 1; count5 < 11; count5++)
                            {
                                cards = new List<int>() { count1, count2, count3, count4, count5 };
                                score = CalculateScore(cards);
                                if(score.Valid && score.Value.Equals(requiredScore))
                                {
                                    break;
                                }
                            }
                            if (score.Valid && score.Value.Equals(requiredScore))
                            {
                                break;
                            }
                        }
                        if (score.Valid && score.Value.Equals(requiredScore))
                        {
                            break;
                        }
                    }
                    if (score.Valid && score.Value.Equals(requiredScore))
                    {
                        break;
                    }
                }
                if (score.Valid && score.Value.Equals(requiredScore))
                {
                    break;
                }
            }
            return cards;
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

