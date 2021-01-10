using System;

namespace HWLesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number #1");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter number #2");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (DivWithoutRemainder(num1, num2))
            {
                Console.WriteLine("no module");
            }
            else
            {
                Console.WriteLine("some module");
            }

            Console.WriteLine("=================");

            ChangingNumbers(ref num1, ref num2);
            Console.WriteLine($"number #1: {num1}");
            Console.WriteLine($"number #2: {num2}");

            Console.WriteLine("=================");

            int c, d;
            GetNumber(out c, out d);
            Console.WriteLine($"c: {c}");
            Console.WriteLine($"d: {d}");

            Console.WriteLine("=================");

            Console.WriteLine(Sum(1, 2, 3));

            Console.WriteLine(Multiplication(1, 2, 3));
            Console.WriteLine(Multiplication(c: 10, a: 1));

            Console.WriteLine("=================");

            int[] arr_ = { 1, -1, 2, -2, 5, -5 };
            int[] arr_pos;
            int[] arr_neg;
            PosAndNeg(arr_, out arr_pos, out arr_neg);

            for (int i = 0; i < arr_pos.Length; i++)
            {
                Console.Write($"{arr_pos[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i < arr_neg.Length; i++)
            {
                Console.Write($"{arr_neg[i]} ");
            }
            Console.WriteLine();

        }

        private static void PosAndNeg(int[] arr_, out int[] arr_pos, out int[] arr_neg)
        {
            int count_pos = 0, count_neg = 0;

            for (int i = 0; i < arr_.Length; i++)
            {
                if (arr_[i] > 0)
                {
                    count_pos++;
                }
                else
                {
                    count_neg++;
                }
            }
            arr_pos = new int[count_pos];
            arr_neg = new int[count_neg];

            int i_arr_pos = 0, i_arr_neg = 0;

            for (int i = 0; i < arr_.Length; i++)
            {
                if (arr_[i] > 0)
                {
                    arr_pos[i_arr_pos] = arr_[i];
                    i_arr_pos++;
                }
                else if (arr_[i] < 0)
                {
                    arr_neg[i_arr_neg] = arr_[i];
                    i_arr_neg++;
                }
            }
        }

        private static int Multiplication(int a, int b=1, int c=1)
        {
            int result = a * b * c;
            return result;
        }

        private static double Sum(params int [] numbers)
        {
            double sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                double pow = Math.Pow(numbers[i], i + 1);
                sum += pow;
            }
            return sum;
        }

        private static void GetNumber(out int c, out int d)
        {
            Console.Write("Please enter number c: ");
            c = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter number d: ");
            d = Convert.ToInt32(Console.ReadLine());
        }

        private static void ChangingNumbers(ref int a, ref int b)
        {
            a++;
            b *= 2;
        }

        private static bool DivWithoutRemainder(int a, int b)
        {
            if (a % b == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
