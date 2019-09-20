using System;
using System.Diagnostics;

namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
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
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            Console.WriteLine(r5);

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
                // Write your code here
                int digit = 0;
                int temp;
                int flag = 1; //flag==1 means number is self dividing, and 0 means it is not.
                Debug.WriteLine("_____________________");
                Debug.WriteLine("Self Dividing Numbers");
                Debug.WriteLine("_____________________");
                while (y >= x)
                {
                    temp = y;
                    while (flag == 1 && temp > 0)
                    {
                        digit = temp % 10;
                        if (!IsSelfDividing(digit, temp))
                            flag = 0;
                        temp /= 10;
                    }
                    if (flag == 1)
                        Debug.Write(y + ", ");
                    y--;
                    flag = 1;
                }
                Debug.WriteLine("");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        public static bool IsSelfDividing(int digit, int num)
        {
            // If the digit divides the number 
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
                // Write your code here
                Debug.WriteLine("____________");
                Debug.WriteLine("Print Series");
                Debug.WriteLine("____________");
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Debug.Write(i + " ");
                    }
                }
                Debug.WriteLine("");
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
                // Write your code here
                Debug.WriteLine("_________________");
                Debug.WriteLine("Inverted Triangle");
                Debug.WriteLine("_________________");
                for (int i = n; i >= 1; --i)
                {
                    for (int space = 0; space < n - i; ++space)
                        Debug.Write("  ");
                    for (int j = i; j <= 2 * i - 1; ++j)
                        Debug.Write("* ");
                    for (int j = 0; j < i - 1; ++j)
                        Debug.Write("* ");
                    Debug.WriteLine("\n");
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
                // Write your code here
                Debug.WriteLine("________________");
                Debug.WriteLine("Jewels in Stones");
                Debug.WriteLine("________________");
                foreach (int j in J)
                {
                    foreach (int s in S)
                    {
                        if (j == s)
                        {
                            count++;
                        }
                    }
                }
                Debug.WriteLine("count " + count);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return count;
        }

        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }

            return null; // return the actual array
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
                Debug.WriteLine("____________");
                Debug.WriteLine("Solve Puzzle");
                Debug.WriteLine("____________");
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
                    Debug.WriteLine(uber + " + " + cool + " = " + uncle);
                }
            }
        }
    }
}
