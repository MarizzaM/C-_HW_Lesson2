using System;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Memory Game!");

            int size = SelectDifficulty();
            if (size == 2 || size == 4 || size == 8)
            {
                int number_of_pairs = size * size / 2;

                char[,] matrix = SpreadTheCards(size);

                PrintMatrix(size, matrix);

                int row_card_1, col_card_1;
                int row_card_2, col_card_2;

                char[,] matrix_tmp = CreateMatrixTmp(size);

                PrintMatrixTmp(size, matrix_tmp);

                int counter1 = 0, counter2 = 0;
                do
                {
                    Console.WriteLine("PLAYER 1");
                    PlayerTurn(size, matrix, out row_card_1, out col_card_1, out row_card_2, out col_card_2, matrix_tmp);

                    while (matrix[row_card_1 - 1, col_card_1 - 1] == matrix[row_card_2 - 1, col_card_2 - 1])
                    {
                        RemoveGuessedCards(matrix, row_card_1, col_card_1, row_card_2, col_card_2, matrix_tmp);
                        counter1++;
                        if (counter1 + counter2 != number_of_pairs)
                        {
                            PlayerTurn(size, matrix, out row_card_1, out col_card_1, out row_card_2, out col_card_2, matrix_tmp);
                        }
                        else
                        {
                            break;
                        }
                    }
                    matrix_tmp[row_card_1 - 1, col_card_1 - 1] = '*';
                    matrix_tmp[row_card_2 - 1, col_card_2 - 1] = '*';
                    if (counter1 + counter2 != number_of_pairs)
                    {
                        Console.WriteLine("PLAYER 2");
                        PrintMatrixTmp(size, matrix_tmp);
                        PlayerTurn(size, matrix, out row_card_1, out col_card_1, out row_card_2, out col_card_2, matrix_tmp);
                        while (matrix[row_card_1 - 1, col_card_1 - 1] == matrix[row_card_2 - 1, col_card_2 - 1])
                        {
                            RemoveGuessedCards(matrix, row_card_1, col_card_1, row_card_2, col_card_2, matrix_tmp);
                            counter2++;
                            if (counter1 + counter2 != number_of_pairs)
                            {
                                PlayerTurn(size, matrix, out row_card_1, out col_card_1, out row_card_2, out col_card_2, matrix_tmp);
                            }
                            else
                            {
                                break;
                            }
                        }
                        matrix_tmp[row_card_1 - 1, col_card_1 - 1] = '*';
                        matrix_tmp[row_card_2 - 1, col_card_2 - 1] = '*';
                        if (counter1 + counter2 == number_of_pairs)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                } while (counter1 + counter2 < number_of_pairs);
            }
        }

        private static void RemoveGuessedCards(char[,] matrix, int row_card_1, int col_card_1, int row_card_2, int col_card_2, char[,] matrix_tmp)
        {
            matrix[row_card_1 - 1, col_card_1 - 1] = ' ';
            matrix[row_card_2 - 1, col_card_2 - 1] = ' ';
            matrix_tmp[row_card_1 - 1, col_card_1 - 1] = ' ';
            matrix_tmp[row_card_2 - 1, col_card_2 - 1] = ' ';
        }

        private static void PlayerTurn(int size, char[,] matrix, out int row_card_1, out int col_card_1, out int row_card_2, out int col_card_2, char[,] matrix_tmp)
        {
            ChooseCard(out row_card_1, out col_card_1, 1);
            CheckAndPrintFirstCard(size, matrix, ref row_card_1, ref col_card_1, matrix_tmp);

            ChooseCard(out row_card_2, out col_card_2, 2);
            CheckAndPrintSecondCard(size, matrix, row_card_1, col_card_1, ref row_card_2, ref col_card_2, matrix_tmp);
        }

        private static void CheckAndPrintSecondCard(int size, char[,] matrix, int row_card_1, int col_card_1, ref int row_card_2, ref int col_card_2, char[,] matrix_tmp)
        {
            while (row_card_2 <= 0 || row_card_2 > size || col_card_2 <= 0 || col_card_2 > size)
            {
                Console.WriteLine($"Error! Please enter number from 1 to {size}: ");
                ChooseCard(out row_card_1, out col_card_1, 2);
            }
            while (matrix[row_card_2 - 1, col_card_2 - 1] == ' ' || row_card_2 - 1 == row_card_1 - 1 && col_card_2 - 1 == col_card_1 - 1)
            {
                Console.WriteLine($"Error! The card is already open");
                ChooseCard(out row_card_1, out col_card_1, 2);
            }
            matrix_tmp[row_card_2 - 1, col_card_2 - 1] = matrix[row_card_2 - 1, col_card_2 - 1];
            PrintMatrixTmp(size, matrix_tmp);
        }

        private static void CheckAndPrintFirstCard(int size, char[,] matrix, ref int row_card_1, ref int col_card_1, char[,] matrix_tmp)
        {
            while (row_card_1 <= 0 || row_card_1 > size || col_card_1 <= 0 || col_card_1 > size)
            {
                Console.WriteLine($"Error! Please enter number from 1 to {size}: ");
                ChooseCard(out row_card_1, out col_card_1, 1);
            }
            while (matrix[row_card_1 - 1, col_card_1 - 1] == ' ')
            {
                Console.WriteLine($"Error! The card is already open");
                ChooseCard(out row_card_1, out col_card_1, 1);
            }
            matrix_tmp[row_card_1 - 1, col_card_1 - 1] = matrix[row_card_1 - 1, col_card_1 - 1];
            PrintMatrixTmp(size, matrix_tmp);
        }

        private static void PrintMatrixTmp(int size, char[,] matrix_tmp)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix_tmp[i, j] + " "); ;
                }
                Console.WriteLine();
            }
        }

        private static char[,] CreateMatrixTmp(int size)
        {
            char[,] matrix_tmp = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix_tmp[i, j] = '*';
                }
            }
            return matrix_tmp;
        }

        private static void ChooseCard(out int row_card, out int col_card, int index)
        {
            Console.Write($"Please enter row for card #{index}: ");
            row_card = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Please enter column for card #{index}: ");
            col_card = Convert.ToInt32(Console.ReadLine());
        }

        private static void PrintMatrix(int size, char[,] matrix)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static char[,] SpreadTheCards(int size)
        {
            Random randomGenerator = new Random();
            char[,] matrix = new char[size, size];
            int number_of_pairs = size * size / 2;
            for (int k = 1; k <= number_of_pairs; k++)
            {
                char card = (char)randomGenerator.Next('A', 'Z' + 1);
                int count = 1;
                int i_row, i_col;
                while (count <= 2)
                {
                    do
                    {
                        i_row = randomGenerator.Next(0, size);
                        i_col = randomGenerator.Next(0, size);
                    }
                    while (matrix[i_row, i_col] != 0);
                    matrix[i_row, i_col] = card;
                    count++;
                }
            }
            return matrix;
        }

        private static int SelectDifficulty()
        {
            Console.Write("Select difficulty (1, 2, or 3): ");
            int difficulty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int size = 0;
            switch (difficulty)
            {
                case 1:
                    Console.WriteLine("Easy - 4 cards");
                    size = 2;
                    break;
                case 2:
                    Console.WriteLine("Medium - 16 cards");
                    size = 4;
                    break;
                case 3:
                    Console.WriteLine("Hard - 68 cards");
                    size = 8;
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            Console.WriteLine();
            return size;
        }
    }
}
