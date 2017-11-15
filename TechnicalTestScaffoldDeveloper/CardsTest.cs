using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestScaffoldDeveloper
{
    public class CardsTest
    {
        private static int[] GetInput()
        {
            // Just use the example to get us started
            //return new int[] { 1, 1, 1, 1, 1 };
            //return new int[] { 3, 3, 3, 2, 10 };
            try
            {
                Console.WriteLine("Please enter 5 card values between 1 and 10.");
                Console.WriteLine("Separate values with a comma.");
                return FormatStringToIntArray(Console.ReadLine());
            }
            catch
            {
                return null;
            }
        }

        public static int[] FormatStringToIntArray(string data)
        {
            try
            {
                string[] splitData = data.Split(',');
                List<int> outputData = new List<int>();
                foreach (string card in splitData)
                {
                    outputData.Add(Int32.Parse(card.Trim()));
                }
                return outputData.ToArray();
            }
            catch
            {
                return null;
            }
        }

        public static Results CalculateScore(int[] cards)
        {
            // Hopefully this won't return 0 for long....
            Results results = new Results();
            if (CheckCardRange(cards))
            {
                int scoreFromMatching = CountMatching(cards.ToList());
                if (scoreFromMatching > 4)
                {
                    results.valid = false;
                    results.errorType = "Duplicate cards";
                }
                else
                {
                    int scoreFromAddition = CountCombinationsWhichAdd(cards.ToList(), 15);
                    int total = scoreFromAddition + scoreFromMatching;
                    results.score = total;
                }
            }
            else
            {
                results.valid = false;
                results.errorType = "Card values out of range";
            }

            return results;
        }

        public static bool CheckCardRange(int[] cards)
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
                for(int j = i + 1; j < cards.Count();j++)
                {
                    if (cards[i].Equals(cards[j]))
                        runningScore ++;
                }
            }
            return runningScore;
        }

        public static int CountCombinationsWhichAdd(List<int> cards, int goalValue)
        {
            return CountCombinationsWhichAdd(0, cards.ToList(), goalValue,0);
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


        private static void OutputScore(int score)
        {
            Console.Out.WriteLine(String.Format("Your score is: {0}", score));
        }

        private static void OutputCards(int[] cards)
        {
            // This might be handy for debugging
            try
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    Console.Out.WriteLine(String.Format("Card {0}: {1}", i, cards[i]));
                }
            }
            catch
            {
            }
        }

        static void Main(string[] args)
        {
            bool game = true;

            while (game)
            {
                int[] cards = GetInput();
                OutputCards(cards);
                Results score = CalculateScore(cards);
                if (score.valid)
                {
                    OutputScore(score.score);
                }
                else
                {
                    Console.WriteLine($"Invalid cards chosen! {score.errorType}");
                }

                Console.WriteLine("Press return to play again");
                Console.ReadLine();

            }
        }

        public class Results
        {
            public int score { get; set; }
            public bool valid { get; set; }
            public string errorType { get; set; }
            public Results()
            {
                this.valid = true;
            }
        }
    }
}
