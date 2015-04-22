using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {2,-3,2,-1};
            //Console.WriteLine(Solution(1000000000));
            //var list = Solution1(A);
            //list.ForEach(i=>Console.WriteLine(i));
            Console.WriteLine(solution4(A));
            Console.ReadLine();
        }

        static int Solution(int N)
        {
            
            int period = -1;
            if (!(N >= 1 && N <= 1000000000))
            {
                return 0;
            }
            string Base2String = Convert.ToString(N,2);
            int length =Base2String.Length;
            for (int i =1; i <= length/2; i++)
            {
                int j = i;
                for (; j < length; j++)
                {
                    if (Base2String[j]==Base2String[j%i])
                    {
                        continue;
                    }
                    break;
                }
                if (j == length)
                {
                    period = i;
                    break;
                }
            }
            
            return period;
        }

        static int Solution1(int[] A)
        {
            List<int> list = new List<int>();
            List<int> resInts = new List<int>();
            int length = A.Length;
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += A[i];
                list[i] = sum;
            }
            for (int i = 0; i < length; i++)
            {
                if (list[i] - A[i] == list[length-1] - list[i])
                {
                   resInts.Add(i);
                }
            }
            if (resInts.Count != 0)
            {
                return resInts[0];
            }
            return -1;
        }

        static int soluton3(int A, int B, int C, int D )
        {
            int max1, max2, max3, max4;
            List<int> list = new List<int>(){A,B,C,D};
            list.Sort();
            int sum = Math.Abs(list[3] - list[0]) + Math.Abs(list[0] - list[2]) + Math.Abs(list[2] - list[1]);
            return sum;
        }

        static int solution4 (int[] A)
        {
            int length = A.Length;
            List<int> list = new List<int>();
            for (int i = 0; i < length; i++)
            {
                list.Add(0);
            }
            int index = 0;
            int numOfHops = 0;
            while (true)
            {
                list[index] = 1;
                index += A[index];
                numOfHops++;
                if (index >=length || index < 0)
                {
                    return numOfHops;
                }
                if (list[index] == 1)
                {
                    return -1;
                }
            }
                
            
        }
    }
}
