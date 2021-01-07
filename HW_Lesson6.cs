using System;

namespace HWLesson6
{
    class Program
    {
        static void Main(string[] args)
        {
           task_1();
           task_2();
           task_3();
           task_4();

        }

        private static void task_4()
        {
            Random randomGenerator = new Random();
            Console.Write("Please enter the number of groups:");
            int number_of_groups = Convert.ToInt32(Console.ReadLine());
            float[] avg_arr = new float[number_of_groups];
            int[][] grades = new int[number_of_groups][];
            for (int i = 0; i < grades.GetLength(0); i++)
            {
                Console.Write($"Please enter the number of students for group #{i + 1}: ");
                int number_of_students = Convert.ToInt32(Console.ReadLine());

                grades[i] = new int[number_of_students];

                for (int j = 0; j < grades[i].Length; j++)
                {
                    Console.Write($"Please enter grade for student #{j + 1} from group #{i + 1}: ");
                    grades[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            int sum;
            float avg;
            for (int i = 0; i < grades.GetLength(0); i++)
            {
                sum = 0;
                avg = 0;
                for (int j = 0; j < grades[i].Length; j++)
                {
                    sum += grades[i][j];
                }
                avg = sum / grades[i].Length;
                avg_arr[i] = avg;
            }
            float max_avg = 0;
            int index = 0;
            for (int i = 0; i < avg_arr.GetLength(0); i++)
            {
                if (max_avg < avg_arr[i])
                {
                    max_avg = avg_arr[i];
                    index = i + 1;
                }
            }
            Console.WriteLine($"The highest average is {max_avg} of the group # {index}");
        }

        private static void task_3()
        {
            Random randomGenerator = new Random();
            int[,] mtrx = new int[3, 3];
            for (int i = 0; i < mtrx.GetLength(0); i++)
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    mtrx[i, j] = randomGenerator.Next(0, 2);
                }
            }

            int count_0 = 0;
            for (int i = 0; i < mtrx.GetLength(0); i++)
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    if (mtrx[i, j] == 0)
                    {
                        count_0++;
                    }

                }
            }
            int counter = 0;
            for (int i = 0; i < mtrx.GetLength(0); i++)
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    while (count_0 < 9)
                    {
                        Console.Write("Please enter row number (1..3): ");
                        int row_number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter column number (1..3): ");
                        int column_number = Convert.ToInt32(Console.ReadLine());
                        if (mtrx[row_number - 1, column_number - 1] == 1)
                        {
                            Console.WriteLine("Boom");
                            mtrx[row_number - 1, column_number - 1] = 0;
                            count_0++;
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("Miss");
                        }
                    }
                }
            }
            Console.WriteLine($"{counter} attempts ");
        }

        private static void task_2()
        {
            Random randomGenerator = new Random();
            int[,] matrix = new int[5, 5];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = randomGenerator.Next(1, 10);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.Write("Please enter number from 1 to 10: ");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (number == matrix[i, j])
                    {
                        Console.WriteLine($"Number {number} was entered to sell: {i}, {j}");
                    }
                }
            }
        }

        private static void task_1()
        {
            Console.Write("Please enter the number of students per class: ");
            int number_of_students = Convert.ToInt32(Console.ReadLine());
            int[] students = new int[number_of_students];

            for (int i = 0; i < number_of_students; i++)
            {
                Console.WriteLine($"Please enter grade for student #{i}: ");
                students[i] = Convert.ToInt32(Console.ReadLine());
            }

            int sum = 0;

            for (int i = 0; i < number_of_students; i++)
            {
                sum += students[i];
            }

            float avg = sum / students.Length;

            Console.WriteLine($"sum of the grades: {sum}");
            Console.WriteLine($"average of the grades: {avg}");
        }
    }
}
