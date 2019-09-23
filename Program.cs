using System;
using System.Diagnostics;

namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Priyanka Sariya, Assignment 1 - Programming Introduction");
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);

            int n2 = 5;
            printSeries(n2);

            int n3 = 5;
            printTriangle(n3);

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);

            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            //int[] r5 = getLargestCommonSubArray(arr1, arr2);
            //Console.WriteLine(r5);
            getLargestCommonSubArray(arr1, arr2);

            solvePuzzle();
        }

        public static void printSelfDividingNumbers(int x, int y)
        {
            /*
            * x – starting range, integer (int)
            * y – ending range, integer (int)
            * 
            * summary      : This method prints all the self-dividing numbers between x and y. 
            * A self-dividing number is a number that is divisible by every digit it contains.
            * 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0 and 128 % 8 == 0
            * For example 1, 22 will print all the self.-dividing numbers between 1 and 22 i.e. 
            * 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22
            * Tip: Write a method isSelfDividing() to compute if a number is self-dividing or not.
            *
            * returns      : N/A
            * return type  : void
            *
            */

            try
            {
                // declare variables
                int digit = 0;
                int temp;
                int flag = 1; //flag==1 means number is self dividing, and 0 means it is not. 
                              //to start with, lets assume the input number is self dividing
                Console.WriteLine("");
                Console.WriteLine("_____________________");
                Console.WriteLine("Self Dividing Numbers");
                Console.WriteLine("_____________________");
                while (y >= x) //continue looping until the 2nd number is less than the 1st number
                {
                    temp = y; //assign y to temp var, you'll see why.
                    while (flag == 1 && temp > 0)
                    {
                        digit = temp % 10; //modulus 10 gives the remainder of temp/10
                        if (!IsSelfDividing(digit, temp)) //if true, then number is not self dividing. note the exclamation mark
                            flag = 0;
                        temp /= 10; //divide temp by 10, and save it to temp
                    }
                    if (flag == 1) //if by the end of the inner while loop, flag is still 1, then our number is self dividing, print it before you lose it.
                        Console.Write(y + ", ");
                    y--; //this will reduce y by 1. keeps the outer while loop in check
                    flag = 1; //resets out flag indicator to 1 again. to assume our new Y is self dividing to start with.
                }
                Console.WriteLine("");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        public static bool IsSelfDividing(int digit, int num)
        {
            // If the digit divides the whole number 
            // then return true else return false. 
            if (digit != 0 && num % digit == 0)
                return true;
            else
                return false;
        }
        public static void printSeries(int n)
        {
            /*
            * n – number of terms of the series, integer (int)
            * 
            * summary        : This method prints the following series till n terms:
            * 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6 …. n terms
            * For example, if n = 5, output will be
            * 1, 2, 2, 3, 3
            *
            * returns        : N/A
            * return type    : void
            */

            try
            {
                Console.WriteLine("");
                Console.WriteLine("____________");
                Console.WriteLine("Print Series");
                Console.WriteLine("____________");
                int temp = n; //this temo will be used to control the loop that that if n is 5, it'll print only 5 digits. you'll see.
                for (int i = 1; i <= n; i++) // this loop will provide the number to be printed.
                {
                    for (int j = 1; j <= i && --temp >= 0; j++) //this loop will print each i, i times and also print exactly n (or temp) digits.
                    {
                        Console.Write(i + " ");
                    }
                }
                Console.WriteLine("");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        public static void printTriangle(int n)
        {
            /*
            * n – number of lines for the pattern, integer (int)
            * 
            * summary      : This method prints an inverted triangle using *
            * For example n = 5 will display the output as: 
            *********
             *******
              *****
               ***
                *

            *
            * returns      : N/A
            * return type  : void
            */

            try
            {
                Console.WriteLine("");
                Console.WriteLine("_________________");
                Console.WriteLine("Inverted Triangle");
                Console.WriteLine("_________________");
                for (int i = n; i >= 1; --i) // this loop controls the number of star lines to be printed. 
                {
                    for (int space = 0; space < n - i; ++space) //this prints the spaces before the stars are printed
                        Console.Write("  ");
                    for (int j = i; j <= 2 * i - 1; ++j) // this prints the leading stars of a line
                        Console.Write("* ");
                    for (int j = 0; j < i - 1; ++j) //this prints the trailing stars of the above line
                        Console.Write("* ");
                    Console.WriteLine("\n");// start a new line for new stars
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static int numJewelsInStones(int[] J, int[] S)
        {
            /*
            * a – array of elements, integer (int)
            * 
            * summary      : You're given an array J representing the types of stones that are 
            * jewels, and S representing the stones you have.  Each element in S is a type of 
            * stone you have.  You want to know how many of the stones you have are also jewels.
            * The elements in J are guaranteed distinct.
            * The function should return an integer.
            * For example:
            * J = [1,3], S = [1,3,3,2,2,2,2,2] will return the output: 
            * 3 (since 1, 3, 3 are jewels)
            * and
            * J = [2], S = [0,0] will return the output: 
            * 0
            *
            * returns      : Integer
            * return type  : int
            */
            int count = 0;
            try
            {
                Console.WriteLine("");
                Console.WriteLine("________________");
                Console.WriteLine("Jewels in Stones");
                Console.WriteLine("________________");
                foreach (int j in J) //for each integer j in the J array
                {
                    foreach (int s in S) //for each integer s in the S array
                    {
                        if (j == s) //if the numbers match, then increase the count
                        {
                            count++;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return count; //return the count
        }

        public static void getLargestCommonSubArray(int[] a, int[] b)
        {
            /*
            * a – array of elements, integer (int)
            * 
            * summary      : This method finds the largest common contiguous subarray from two 
            * sorted arrays. The given arrays are sorted in ascending order. If there are multiple 
            * arrays with the same length, then return the last array having the maximum length.
            * The function should return the array.
            * For example:
            * a = [1,2,5,6,7,8,9], b = [1,2,3,4,5] will return the output: 
            * [1,2]
            * and
            * a = [1,2,3,4,5,6,7,8,9], b = [1,2,5,7,8,9,10] will return the output: 
            * [7,8,9]
            * and
            * a = [1,2,3,4,5,6], b = [1,2,5,6,7,8,9] will return the output: 
            * [5,6]
            *
            * returns      : Array of integers
            * return type  : int[]
            */

            try
            {
                Console.WriteLine("");
                Console.WriteLine("_______________________");
                Console.WriteLine("Longest Common Subarray");
                Console.WriteLine("_______________________");

                int lenA = 0, lenB = 0;
                //Find the length of each input array
                foreach (int p in a) lenA++;
                foreach (int q in b) lenB++;

                string strA = string.Join("", a); //Convert int array to string
                string strB = string.Join("", b); //Convert int array to string

                int[,] lenArr = new int[lenA, lenB]; //create a 2D array
                int len = 0;
                string result = ""; //this will hold the output

                //find the longest common subarray
                for (int i = 0; i < lenA; i++)
                {
                    for (int j = 0; j < lenB; j++)
                    {
                        if (strA[i] == strB[j])//match each char of strA to all char of strB
                        {
                            //If the row and column values match and are across the diagonals, 
                            //increment the value of lenArr by 1. 
                            //If it is a match but not across the diagonals, then assign a value of 1
                            //In case of no match in values, assign a 0
                            lenArr[i, j] = i == 0 || j == 0 ? 1 : lenArr[i - 1, j - 1] + 1;
                            if (lenArr[i, j] > len)
                            {
                                len = lenArr[i, j];
                                result = strA.Substring(i - len + 1, len);//Output the substring which match and are across the diagonals
                            }
                        }
                        else
                            lenArr[i, j] = 0;
                    }
                }
                if (len == 0) // if true, then no common substring exists 
                    result = "No Common Substring";
                //Print the resultant array of string
                Console.Write("Result: [");
                foreach (var c in result)
                    Console.Write(c + ",");
                Console.WriteLine("]");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }

            //return null; // return the actual array
        }
        
        public static void solvePuzzle()
        {
            //Solve Cryptarithm
            //    UBER
            //   +COOL
            //  =UNCLE
            // by assigning a number to each alphabet, such that the resultant numbers set in the above equation successfully!

            try
            {
                Console.WriteLine("");
                Console.WriteLine("____________");
                Console.WriteLine("Solve Puzzle");
                Console.WriteLine("____________");
                UC(1, 8, 2, 3, 4, 5, 6, 7, 9, 0);
                UC(1, 9, 2, 3, 4, 5, 6, 7, 8, 0);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }

        static void UC(int u, int c, int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8)
        {
            // "U***" + "C***" = "U*C**"
            // Pick any value for R
            UCR(u, c, v1, v2, v3, v4, v5, v6, v7, v8);
            UCR(u, c, v2, v1, v3, v4, v5, v6, v7, v8);
            UCR(u, c, v3, v1, v2, v4, v5, v6, v7, v8);
            UCR(u, c, v4, v1, v2, v3, v5, v6, v7, v8);
            UCR(u, c, v5, v1, v2, v3, v4, v6, v7, v8);
            UCR(u, c, v6, v1, v2, v3, v4, v5, v7, v8);
            UCR(u, c, v7, v1, v2, v3, v4, v5, v6, v8);
            UCR(u, c, v8, v1, v2, v3, v4, v5, v6, v7);
        }

        static void UCR(int u, int c, int r, int v1, int v2, int v3, int v4, int v5, int v6, int v7)
        {
            // "U**R" + "C***" = "U*C**"
            // Pick any value for L
            UCRL(u, c, r, v1, v2, v3, v4, v5, v6, v7);
            UCRL(u, c, r, v2, v1, v3, v4, v5, v6, v7);
            UCRL(u, c, r, v3, v1, v2, v4, v5, v6, v7);
            UCRL(u, c, r, v4, v1, v2, v3, v5, v6, v7);
            UCRL(u, c, r, v5, v1, v2, v3, v4, v6, v7);
            UCRL(u, c, r, v6, v1, v2, v3, v4, v5, v7);
            UCRL(u, c, r, v7, v1, v2, v3, v4, v5, v6);
        }

        static void UCRL(int u, int c, int r, int l, int v1, int v2, int v3, int v4, int v5, int v6)
        {
            // Solve for E
            // "U*?R" + "C**L" = "U*CL?"
            int e = (r + l) % 10;
            if (v1 == e) UCRLE(u, c, r, l, e, v2, v3, v4, v5, v6);
            else if (v2 == e) UCRLE(u, c, r, l, e, v1, v3, v4, v5, v6);
            else if (v3 == e) UCRLE(u, c, r, l, e, v1, v2, v4, v5, v6);
            else if (v4 == e) UCRLE(u, c, r, l, e, v1, v2, v3, v5, v6);
            else if (v5 == e) UCRLE(u, c, r, l, e, v1, v2, v3, v4, v6);
            else if (v6 == e) UCRLE(u, c, r, l, e, v1, v2, v3, v4, v5);
        }

        static void UCRLE(int u, int c, int r, int l, int e, int v1, int v2, int v3, int v4, int v5)
        {
            // Pick any value for B
            UCRLEB(u, c, r, l, e, v1, v2, v3, v4, v5);
            UCRLEB(u, c, r, l, e, v2, v1, v3, v4, v5);
            UCRLEB(u, c, r, l, e, v3, v1, v2, v4, v5);
            UCRLEB(u, c, r, l, e, v4, v1, v2, v3, v5);
            UCRLEB(u, c, r, l, e, v5, v1, v2, v3, v4);
        }

        static void UCRLEB(int u, int c, int r, int l, int e, int b, int v1, int v2, int v3, int v4)
        {
            // Solve for O in Ten's position
            // "UBER" + "C??L" = "U*CLE"
            int carry = (r + l) / 10;
            int o = (10 + l - (e + carry)) % 10;

            if (v1 == o) UCRLEBO(u, c, r, l, e, b, o, v2, v3, v4);
            else if (v2 == o) UCRLEBO(u, c, r, l, e, b, o, v1, v3, v4);
            else if (v3 == o) UCRLEBO(u, c, r, l, e, b, o, v1, v2, v4);
            else if (v4 == o) UCRLEBO(u, c, r, l, e, b, o, v1, v2, v3);
        }

        static void UCRLEBO(int u, int c, int r, int l, int e, int b, int o, int v1, int v2, int v3)
        {
            // Solve for N in Thousand's position
            // "UBER" + "COOL" = "U?CLE"
            int carry = (100 * b + 10 * e + r + 100 * o + 10 * o + l) / 1000;
            int n = (u + c + carry) % 10;

            if ((v1 == n) || (v2 == n) || (v3 == n))
            {
                // check O is valid in thousands position
                // "UBER" + "COOL" = "UNCLE"
                int uber = 1000 * u + 100 * b + 10 * e + r;
                int cool = 1000 * c + 100 * o + 10 * o + l;
                int uncle = 10000 * u + 1000 * n + 100 * c + 10 * l + e;

                // Check this solution
                if ((uber + cool) == uncle)
                {
                    Console.WriteLine(uber + " + " + cool + " = " + uncle);
                }
            }
        }
    }
}
