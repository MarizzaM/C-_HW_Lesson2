using System;

namespace HWLesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            // =Task #1=
                       int num = 1;
                       while (num <= 2000)
                       {
                           Console.WriteLine(num + " ");
                           num++;
                       }

            //           for (int i = 2; i <= 100; i += 2)
                       for (int i = 10; i <= 100; i += 10)
                           {
                           Console.WriteLine(i + " ");
                       }

            // =Task #2=
            for (int i = 100; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
                         

            // =Task #3=
            Console.WriteLine("Please enter number: ");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a/10 > 1 && a / 10 < 10)
            {
                Console.WriteLine(a%10);
                Console.WriteLine(a/10);
                if (a % 10 > a / 10)
                {
                    Console.WriteLine("AHADOT");
                }
                else if (a % 10 < a / 10)
                {
                    Console.WriteLine("ASAROT");
                } 
                else
                {
                    Console.WriteLine("AHADOT = ASAROT");
                }
            } 
            // =Task #4=
            for (a = 2; a <= 100; a++)
            {
                int b = 2;
                while (a % b != 0 && b < a)
                {
                    b++;
                }
                if (a == b || a == 1)
                {
                    Console.WriteLine(a);
                }
            }

            // =Task #5=
            int[] bills = { 200, 100, 50, 10, 5, 1 };
            int sum = 520;
            int count_bills;
            for(int i = 0; i < bills.Length; i++)
            {
                if (sum >= bills[i])
                {
                    count_bills = sum / bills[i];
                    Console.Write($"{bills[i]} -> ");
                    Console.WriteLine(count_bills);
                    sum -= count_bills * bills[i];
                    continue;
                }
            }
            // =Task #6=
            Console.WriteLine("Please enter number: ");
            int size = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    if (i < j)
                    {
                        Console.Write("*");
                    } else
                    {
                        Console.Write(j);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
