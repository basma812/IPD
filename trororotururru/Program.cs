using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace trororotururru
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your personal ID number to be valdate in form YYYYMMDDXXXX : ");


            string perNum;
            // string form for the user input YYYYMMDDXXXC
            // separate the form into little pieces
            perNum = Console.ReadLine();

            //string perNum = "YYYYMMDDXXXC";

            int YYYY = int.Parse(perNum.Substring(0, 4));
            int MM = int.Parse(perNum.Substring(4, 2));
            int DD = int.Parse(perNum.Substring(6, 2));
            int XXX = int.Parse(perNum.Substring(8, 3));
            int C = int.Parse(perNum.Substring(11, 1));

            
            bool isAnOKID = ID(YYYY, MM);
            if (isAnOKID)
            {

                isAnOKID = CheckTheDays(DD, YYYY, MM);
            }
            if (isAnOKID)
            {
                isAnOKID = BirthNum(XXX);
            }
            if (isAnOKID)
            {
                Console.Write("your ID is Valid and ");
                Gender(XXX);
            }

            Console.ReadKey();
        }
        // make methods for the form pieces

        ////define the range of year and month
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
            if(DateTime.DaysInMonth(YYYY, MM) >= DD)
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
                Console.WriteLine("your gender is a woman"); //checkLuhn(perNum);

            }
            else
            {
                Console.WriteLine("your gender is a man"); //checkLuhn(perNum);
            }
        }

        //static bool checkLuhn(String perNum)
        //{
        //    int nDigits = perNum.Length;
        //    if (perNum.Length == 12)
        //    {
        //        int.TryParse(perNum.Substring(0, 2);
        //    }

        //    int nSum = 0;
        //    bool isSecond = false;
        //    for (int i = nDigits - 1; i >= 0; i--)
        //    {

        //        int d = perNum[i] - '0';

        //        if (isSecond == true)
        //            d = d * 2;

        //        // We add two digits to handle
        //        // cases that make two digits 
        //        // after doubling
        //        nSum += d / 10;
        //        nSum += d % 10;

        //        isSecond = !isSecond;
        //    }
        //    return (nSum % 10 == 0);
        //}

        //static string twelveNumId(string perNum)
        //{
        //    if (perNum.Length == 12)
        //    {
        //        int.TryParse(perNum.Substring(0, 2);
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}



    }
}

            

