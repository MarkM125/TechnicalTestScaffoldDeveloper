using System;
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
            return new int[] { 3, 3, 3, 2, 10 };
        }

        public static int CalculateScore(int[] cards)
        {
            // Hopefully this won't return 0 for long....
            return 0;
        }

        private static void OutputScore(int score)
        {
            // Write to console.
            Console.Out.WriteLine(String.Format("Your score is: {0}", score));
            Console.In.ReadLine();
        }

        private static void OutputCards(int[] cards)
        {
            // This might be handy for debugging
            for (int i = 0; i < cards.Length; i++)
            {
                Console.Out.WriteLine(String.Format("Card {0}: {1}", i, cards[i]));
            }
        }

        static void Main(string[] args)
        {

            int[] cards = GetInput();
            OutputCards(cards);
            int score = CalculateScore(cards);
            OutputScore(score);

        }
    }
}
