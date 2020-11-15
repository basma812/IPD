using System;
using System.Linq;

namespace trororotururru
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your personal ID number to be validated : ");
            string perNum;
            // string form for the user input
            perNum = Console.ReadLine();
            Console.WriteLine("{0}", perNum[6]);
            string haystack = "0123456789+-";
            if (haystack.IndexOf(perNum[6]) == -1)
            {
                Console.WriteLine("Bad letter {0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11} in personal ID number", perNum[0], perNum[1], perNum[2], perNum[3], perNum[4], perNum[5], perNum[6], perNum[7], perNum[8], perNum[9], perNum[10], perNum[11]);
                return;
            }
            if (haystack.IndexOf(perNum[8]) == -1)
            {
                Console.WriteLine("Bad letter {0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13} in personal ID number", perNum[0], perNum[1], perNum[2], perNum[3], perNum[4], perNum[5], perNum[6], perNum[7], perNum[8], perNum[9], perNum[10], perNum[11], perNum[12], perNum[13]);
                return;
            }
            //replace '+' and '-' with empty space
            perNum = perNum.Replace("+", "");
            perNum = perNum.Replace("-", "");
            if (perNum.Length == 10)
                perNum = "19" + perNum;
            if (
               (perNum.Any(p => p.ToString() == "-")
                   || perNum.Any(p => p.ToString() == "+"))
               && !(perNum.Substring(8, 1).ToString() == "-"
                   || perNum.Substring(8, 1).ToString() == "+"))
            {
                Console.WriteLine("Please introduce the character after the date(DD)");
                return;
            }
            // separate the form into little pieces
            int YYYY = int.Parse(perNum.Substring(0, 4));
            int MM = int.Parse(perNum.Substring(4, 2));
            int DD = int.Parse(perNum.Substring(6, 2));
            int XXX = int.Parse(perNum.Substring(8, 3));
            int C = int.Parse(perNum.Substring(11, 1));

            // make sure the date is written right in date range
            bool isAnOKID = ID(YYYY);
            bool CheckCorrect = CheckTheDays(DD, CheckLeapYear, MM);

            if (isAnOKID)
            {

                isAnOKID = CheckCorrect;
            }
            if (isAnOKID)
            {
                isAnOKID = BirthNum(XXX);
            }
            //Using Luhn algorithm which has it's own method to calculate if the numbers entered are valid
            if (checkLuhn(perNum))
            {
                Console.WriteLine("Your ID is Not valid by Luhn");
                return;
            }
            Console.WriteLine("Your ID is valid by Luhn");
            if (isAnOKID)
            {
                Console.Write("your ID is Valid and ");
                Gender(XXX);
            }
            Console.ReadKey();
        }
        // make methods for the form pieces
        //define the range of year and month
        static bool ID(int YYYY)
        {
            
            if (YYYY >= 1753 && YYYY <= 2020)
            {
                    return true;
            }
            else
            {
                return false;
            }
                
        }
        //define the range of the days in the month
        static bool CheckTheDays(int DD, CheckLeapYear, int MM)
        {
            bool CheckCorrect = CheckTheDays(DD, CheckLeapYear, MM);

            if (MM < 1 || MM > 12)
            {
                Console.WriteLine("Du har angett en felaktig månad. Vänlig försök igen.");
                
                if (MM == 2)
                {
                    if (DD > 28 || DD < 1)
                    {
                        Console.WriteLine("Felaktig dag har angetts. Det är ej skottår. Vänlig försök igen.");
                        return false;
                    }
                }
            }
            else
            {
                if (MM == 2)
                {
                    if (DD > 29 || DD < 1)
                    {
                        Console.WriteLine("Felaktig dag har angetts. Vänlig försök igen.");
                        return false;
                    }
                }

            }
            return false;
        }
          // Method that checks if a year is a leap year
        static bool CheckLeapYear(int YYYY)
        {
                if (YYYY % 400 == 0)
                {
                    return true;
                }
                else if (YYYY % 100 == 0)
                {
                    return false;
                }
                else if (YYYY % 4 == 0)
                {
                    return true;
                }
        }

            //define the range of the three numbers
            static bool BirthNum(int XXX)
            {

                if (XXX >= 000 && XXX <= 999)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // gender decided by calculating if the three numbers are even or odd
            static void Gender(int XXX)
        {
            if (XXX % 2 == 0 || XXX == 0)
            {
                Console.WriteLine(" your gender is a woman");
            }
            else
            {
                Console.WriteLine("your gender is a man");
            }
        }
        //the mathematic for Luhn algorithm
        static bool checkLuhn(String perNum)
            {
                int nDigits = perNum.Length;

                int nSum = 0;
                bool isSecond = false;
                for (int i = nDigits - 1; i >= 0; i--)
                {
                    int d = perNum[i] - '0';

                    if (isSecond == true)
                        d = d * 2;

                    // We add two digits to handle
                    // cases that make two digits 
                    // after doubling
                    nSum += d / 10;
                    nSum += d % 10;

                    isSecond = !isSecond;
                }
                return (nSum % 10 == 0);
            }
        }
    }
}