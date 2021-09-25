using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S3_HW_SP_Threas3x
{
    class Program
    {
        static void Main(string[] args)
        {
            int fact, simple, fibo = 0;
            Console.WriteLine("Enter max count (>0) for Factorial: ");
            fact = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter max count (>0) for Simple Numbers: ");
            simple = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter max count (>0) for Fibonachi: ");
            fibo = int.Parse(Console.ReadLine());
            Console.WriteLine("\n==================\n");

            Thread factThread = new Thread(new ParameterizedThreadStart(MaxCountFactorial));
            factThread.Start(fact);
            Thread simpleThread = new Thread(new ParameterizedThreadStart(MaxCountSimple));
            simpleThread.Start(simple);
            Thread fiboThread = new Thread(new ParameterizedThreadStart(MaxCountFibonachi));
            fiboThread.Start(fibo);

            Thread.Sleep(1000);

            if (factThread.ThreadState == System.Threading.ThreadState.Stopped &&
                simpleThread.ThreadState == System.Threading.ThreadState.Stopped &&
                fiboThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                Thread.CurrentThread.Abort();
            }
            Console.ReadLine();
        }

        public static void MaxCountFactorial(object x)
        {
            int maxFact = 0;
            int i = 0;
            while (maxFact <= (int)x)
            {
                i++;
                maxFact = Factorial(i);
            };
            Console.WriteLine("Max factorial before " + (int)x + " : " + (i - 1) + "! = " + Factorial(i - 1));
        }
        public static void MaxCountSimple(object x)
        {
            int maxSimple = 0;
            int temp = 0;
            int i = 0;
            while (temp < (int)x)
            {
                i++;
                if (isSimple(i))
                {
                    maxSimple = temp;
                    temp = i;
                }
            };
            Console.WriteLine("Max simple number before " + (int)x + " : " + maxSimple);
        }
        public static void MaxCountFibonachi(object x)
        {
            int maxFibo = 0;
            int i = 0;
            while (maxFibo <= (int)x)
            {
                i++;
                maxFibo = Fibonachi(i);
            };
            Console.WriteLine("Max fibonachi number before " + (int)x + " : " + Fibonachi(i - 1));
        }
        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        public static bool isSimple(int n)
        {
            for (int i = 2; i < (int)(n / 2); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public static int Fibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }
        public static void Test()
        {
            Console.WriteLine("Test");
        }
    }

}
