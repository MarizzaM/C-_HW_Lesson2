using System;

namespace HWLesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task1");
            Console.Write("Please enter number: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(IsPrime(a));

            Console.WriteLine("Task2");
            int[] arr = { 17, 13, 9, 4, 2 };
            CheckArrayForPrimeNumbers(arr);

            Console.WriteLine("Task3");
            int[] arr1 = { 9, 8, 7, 6, 5 };
            int[] arr2 = { 9, 8, 7, 6, 1 };
            Console.WriteLine(WhichArrayIsBigger(arr1, arr2));
            
            Console.WriteLine("Task4");
            int[,] theMatrix = FillRandom();
            for (int i = 1; i <= 10; i++)
            {
                CheckExist(theMatrix);
            }
            
            Console.WriteLine("Task5");
            int[] array = { -5, -10, 15, 2, 5, 100 };
            SortArray(array);
            PrintArray(array);

        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        private static void SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = array[i];
                int min_i = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        min_i = j;
                    }
                }
                if (min_i != i)
                {
                    int temp = array[i];
                    array[i] = array[min_i];
                    array[min_i] = temp;
                }
            }
        }

        private static void CheckExist(int[,] theMatrix)
        {
            Console.Write("Please enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int flag = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (theMatrix[i, j] == number)
                    {
                        flag = 1;
                    }
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("exist");
            }
            else
            {
                Console.WriteLine("missing");
            }
        }

        private static int[,] FillRandom()
        {
            Random randomGenerator = new Random();
            int[,] matrix = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    matrix[i, j] = randomGenerator.Next(1, 1001);
                }
            }
            return matrix;
        }

        private static int WhichArrayIsBigger(int[] arr1, int[] arr2)
        {
            int result;
            int sum1 = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                sum1 += arr1[i];
            }
            int sum2 = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                sum2 += arr2[i];
            }
            if (sum1 > sum2)
            {
                result = 1;
            }
            else if (sum1 < sum2)
            {
                result = -1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        private static void CheckArrayForPrimeNumbers(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                IsPrime(arr[i]);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]} - {IsPrime(arr[i])}");
            }

        }

        private static int IsPrime(int a)
        {
            int rez;
            int b = 2;
            while (a % b != 0 && b < a)
            {
                b++;
            }
            if (a == b || a == 1)
            {
                rez = 0;
            }
            else
            {
                rez = 1;
            }
            return rez;
        }
    }
}
