using System;

namespace HWLesson3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }

        private static void Task4()
        {
            Console.Write("Please enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int c = 1;
            for (int i = 1; i <= num; i++)
            {
                for (int j = i; j < num; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= c; j++)
                {
                    if (j % 2 != 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                c += 2;
                Console.WriteLine();
            }
        }

        private static void Task3()
        {
            Console.Write("Please enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number; j++)
                {
                    if (j <= i)
                    {
                        Console.Write(j);
                    }
                }
                Console.WriteLine();
            }
            for (int i = number - 1; i >= 1; i--)
            {
                for (int j = 1; j <= number; j++)
                {
                    if (j <= i)
                    {
                        Console.Write(j);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Task2()
        {
            Console.Write("Please enter number of students: ");
            int count = Convert.ToInt32(Console.ReadLine());
            int[] classes = { 100, 30, 10 };
            int count_of_classes;
            for (int i = 0; i < classes.Length; i++)
            {
                if (count >= classes[i])
                {
                    count_of_classes = count / classes[i];
                    Console.WriteLine($"{count_of_classes} classes of {classes[i]} students");
                    count -= count_of_classes * classes[i];
                    if (count < 10)
                    {
                        Console.WriteLine($"{count} students will be released home");
                    }
                    continue;
                }
            }
        }

        private static void Task1()
        {
            int flag = 0;
            while (flag == 0)
            {
                Console.Write("Please enter number: ");
                int a = Convert.ToInt32(Console.ReadLine());
                {
                    int b = 2;
                    while (a % b != 0 && b < a)
                    {
                        b++;
                    }
                    if (a == b || a == 1)
                    {
                        Console.WriteLine($"{a} - prime numbe");
                        flag++;
                    }
                    else
                    {
                        Console.WriteLine($"{a} - composite number");
                    }
                }
            }
        }
    }
}
