using System;
using System.Collections.Generic;
using System.Linq;

namespace exam1_fall19_monday
{
    class Program
    {
        static void Main(string[] args)
        {
            ques1a();
            ques1b();

            Console.WriteLine("question 2");
            Console.WriteLine(IsPrime(7));

            Console.WriteLine("question 2");
            Console.WriteLine(IsPrime(24));

            Console.WriteLine("question 2");
            Console.WriteLine(IsPrime(25));

            Console.WriteLine("question 3");
            Console.WriteLine( RemoveVowels("leetcodeisacommunityforcoders"));
            Console.WriteLine(RemoveVowels2("leetcodeisacommunityforcoders"));

            Console.WriteLine("question 3");
            Console.WriteLine(RemoveVowels("aeiou"));
            Console.WriteLine(RemoveVowels2("aeiou"));

            Console.WriteLine("question 4");
            int[] nums = { 1, 3, 1, 4, 5, 6, 3, 2 };
            Console.WriteLine(CountNonUnique(nums));
            Console.WriteLine(CountNonUnique2(nums));
            Console.WriteLine("question 4");
            int[] nums2 = { 1, 3, 4, 3, 4, 4, 5 };
            Console.WriteLine(CountNonUnique(nums2));
            Console.WriteLine(CountNonUnique2(nums2));

            Console.WriteLine("question 5");
            int[] nums3 = { 1, 12, -5, -6, 50, 3 };
            int k = 4;
            Console.WriteLine(FindMaxAverage(nums3, k));
            Console.WriteLine(FindMaxAverage2(nums3, k));
        }

        public static void ques1a()
        {
            int a = 12, b = 16;
            int i, result = 0;
            for (i = 1; i <= a || i <= b; i++)
            {
                if (a % i == 0 && b % i == 0)
                    result = i;
            }
            Console.WriteLine(result);
        }

        public static void ques1b()
        {
            int[] A = { 12, 35, 10, 35, 1, 34, 15 };
            int x = A[0], y = A[0];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > x)
                {
                    y = x;
                    x = A[i];
                }
                else if (A[i] > y && A[i] != x)
                    y = A[i];
            }
            Console.WriteLine(y);
        }

        public static int IsPrime(int N)
        {
            if (N == 1 || N == 2 || N == 3)
            { return 1; }


            int count = 0;
            int i;

            for (i = 2; i < N; i++)
            {
                if (N % i == 0 && N != i)
                {
                    count++;
                    break;
                }
            }

            if (count > 0)
            { return i; }
            else return 1;
        }

        public static string RemoveVowels(string s)
        {
            String temp = "";
            int start = 0;
            int end = 0;
            int length = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
                {
                    end = i;
                    length = end - start;
                    temp = temp + s.Substring(start, length);
                    start = end + 1;
                }
                if (i == s.Length - 1)
                {
                    end = i;
                    length = end - start+1;
                    temp = temp + s.Substring(start, length);
                    start = end + 1;
                }
            }
            return temp;
        }

        public static string RemoveVowels2(string s)
        {
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (!(s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u'))
                {
                    temp = temp + s[i];
                }
                
            }
            return temp;
        }

        //        [1,3,1,4,5,6,3,2]
        //      [1,3,4,3,4,4,5]
        ///*********this can be order of n2 becuase of Add inside a for loop ********/
        public static int CountNonUnique(int[] numbers)
        {
            int count = 0;
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (d.ContainsKey(numbers[i]) == true)
                {
                    d[numbers[i]] += 1;
                }
                if (d.ContainsKey(numbers[i]) == false)
                {
                    d.Add(numbers[i], 1);
                }
                if (d[numbers[i]] == 2)
                { count += 1; }
            }
            return count;
        }
        ///*******************this is order of n**************/
        public static int CountNonUnique2(int[] numbers)
        {
            int count = 0;
            Dictionary<int, int> d = numbers.Distinct().ToDictionary(key => key, value => 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                if (d.ContainsKey(numbers[i]) == true)
                {
                    d[numbers[i]] += 1;
                }
                
                if (d[numbers[i]] == 2)
                { count += 1; }

            }
            return count;
        }

        // this is order of n square --get range used inside for
        public static double FindMaxAverage(int[] nums, int k)
        {
            double avg = 0;
            double temp_avg = 0;
            List<int> l=nums.ToList();
            List<int> l2;
            for (int i = 0; i < nums.Length; i++)
            {
                if ((i + k) < nums.Length)
                { 
                    l2 = l.GetRange(i, k);
                    temp_avg = Convert.ToDouble(l2.Sum()) / k;
                    if (temp_avg > avg)
                    {  avg = temp_avg;}
                }

            }
            return avg;
        }

        // this is order of n
        public static double FindMaxAverage2(int[] nums, int k)
        {
            double avg = 0;
            int st = 0;
            List<int> l = nums.ToList();

            return FindMaxAverageRecursion(l, k, st, avg);
        }

        public static double FindMaxAverageRecursion(List<int> l, int k,int st,double avg)
        {
            double temp_avg=0;
            if (st + k - 1 < l.Count )
            {
             temp_avg=  Convert.ToDouble(l.GetRange(st, k).Sum())/Convert.ToDouble(k) ;
                st++;
                avg = Math.Max(avg, temp_avg);
            }
            if (st<=l.Count-k)
            {
                return FindMaxAverageRecursion(l, k, st, avg);
            }
            else
            {
                return avg;
            }
        }

    }
}

