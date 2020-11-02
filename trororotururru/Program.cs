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
            bool isAnOKID = ID(YYYY, MM);

            if (isAnOKID)
            {

                isAnOKID = CheckTheDays(DD, YYYY, MM);
            }
            if (isAnOKID)
            {
                isAnOKID = BirthNum(XXX);
            }
            //Using Luhn algorithm which has it's own method to calculate if the numbers entered are valid
            if (checkLuhn(perNum))
            {
                Console.WriteLine("Your ID is Not valid by Lunh");
                return;
            }
            Console.WriteLine("Your ID is valid by Lunh");

            if (isAnOKID)
            {
                Console.Write("your ID is Valid and ");
                Gender(XXX);
            }
            Console.ReadKey();
        }
        // make methods for the form pieces
        //define the range of year and month
        static bool ID(int YYYY, int MM)
        {
            int thisYYYY = DateTime.Now.Year;
            if (YYYY >= 1753 && YYYY <= thisYYYY)
            {
                if (MM >= 0 && MM <= 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        //define the range of the days in the month, using "DateTime.DaysInMonth" 
        //DateTime.DaysInMonth returns the numbers of days in specific year and month (works for leap year)
        static bool CheckTheDays(int DD, int YYYY, int MM)
        {
            if (DateTime.DaysInMonth(YYYY, MM) >= DD)
            {
                return true;
            }
            else
                return false;
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