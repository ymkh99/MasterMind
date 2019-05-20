using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {

        static int min = 1;
        static int max = 6;
        static int maxDigits = 4;

        static void Main(string[] args)
        {
            int matchCount = 0;
            int attempts = 10;



            var randomArray = GetRandonNumber();
            Console.WriteLine("Random number generated, Play and guess...");

            for (int i = 1; i <= attempts; i++) {
                Console.WriteLine("Attempt " + i);
                Console.Write("Enter Input :");
                string input = string.Empty;
                do
                {
                    input = Console.ReadLine();
                    if (input.Length != maxDigits)
                    {
                        Console.WriteLine("Invalid number..enter again");
                        Console.Write("Enter Input :");
                    }
                } while (input.Length != maxDigits);

                var result = CompareNumber(input, randomArray);

                foreach (string s in result)
                {
                    Console.WriteLine(s);
                }

                matchCount=result.Count(r => r.Contains("+"));
                if (matchCount == maxDigits)
                {
                    Console.WriteLine("You Win...you guessed the correct random number " + string.Join("", randomArray));
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect guess...try again.");
                }
            }

            if (matchCount != maxDigits){
                Console.WriteLine("Random number is " + string.Join("",randomArray));
                Console.WriteLine("You loose you could not guess the correct random number in "  + attempts + " attempts");
            }

            Console.ReadKey();

        }

        public static string[] CompareNumber(string inputNumber, int[] randomArray)
        {
            int index;
            int count=0;
            string[] compareMatchArray = new string[maxDigits];
            foreach(char c in inputNumber)
            {
                int k = Convert.ToInt16(c.ToString());
                index = Array.IndexOf(randomArray, k);
                if (index < 0)
                {
                    compareMatchArray[count++] = k.ToString();
                }
                else if (index == count)
                {
                    compareMatchArray[count++] = "+" + k;
                }
                else
                {
                    compareMatchArray[count++] = "-" + k;
                }
            }

            return compareMatchArray;
        }

        public static int[] GetRandonNumber()
        {
            int rm = 0;

            int[] randomArray = new int[maxDigits];

            Random random = new Random();

            for(int i=0; i<maxDigits;)
            {
                rm = random.Next(min, max);
                if (Array.IndexOf(randomArray, rm) < 0)
                {
                    randomArray[i] = rm;
                    i++;
                }
            }

            return randomArray;

        }

    }


}
