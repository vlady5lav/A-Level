using System;

namespace TaskTwo
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("\nWhat task do you prefer: First (type 1) or Second (type 2): ");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    FirstTask();
                    break;
                }
                else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {
                    SecondTask();
                    break;
                }
                else
                {
                    Console.WriteLine("Please, make your choice!");
                    continue;
                }
            }

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Y:
                        Console.Clear();
                        Program.Main(null);
                        break;
                    case ConsoleKey.N:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nPlease, make your choice!\nDo you want to try again? [Y]es/[N]o");
                        continue;
                }
            }
        }

        public static int GetRandom(int minval, int maxval)
        {
            Random randomized = new();
            int rnd = randomized.Next(minval, maxval);
            return rnd;
        }

        public static void FirstTask()
        {
            uint size;

            while (true)
            {
                Console.Write("\nEnter the desired length of the array in numbers: ");
                string length = Console.ReadLine();

                bool isNumber = uint.TryParse(length, out size);

                if (isNumber == true)
                {
                    if (size == 0)
                    {
                        Console.Write("\nAn array with no values makes no sense... Try again...\n");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.Write("\nThis is not a number or the number is negative! Try again...\n");
                }
            }

            int minv;
            int maxv;

            while (true)
            {
                Console.Write("\nEnter the desired minimum value of the random in numbers: ");
                string minrand = Console.ReadLine();

                bool isNumber = int.TryParse(minrand, out minv);

                if (isNumber == true)
                {
                    break;
                }
                else
                {
                    Console.Write("\nThis is not a number! Try again...\n");
                }
            }

            while (true)
            {
                Console.Write("\nEnter the desired maximum value of the random in numbers: ");
                string maxrand = Console.ReadLine();

                bool isNumber = int.TryParse(maxrand, out maxv);

                if (isNumber == true)
                {
                    if (maxv >= minv)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("\nMaximum value cannot be less than minimum value! Try again...\n");
                    }
                }
                else
                {
                    Console.Write("\nThis is not a number! Try again...\n");
                }
            }

            int[] F = new int[size];

            Console.WriteLine($"\nArray:\n");

            for (int i = 0; i < F.Length; i++)
            {
                F[i] = GetRandom(minv, maxv);
                Console.WriteLine($"F[{i}] = {F[i]}");
            }

            int val = 0;
            int sum = 0;

            for (int i = 0; i < F.Length; i++)
            {
                if (F[i] >= -100 && F[i] <= 100)
                {
                    val++;
                    sum += F[i];
                }
            }

            Console.WriteLine($"\nThe values in the range from -100 to +100: {val}!");
            Console.WriteLine($"\nSum of the elements from -100 to 100: {sum}!");
        }

        public static void SecondTask()
        {
            uint adep;
            uint bdep;

            while (true)
            {
                Console.Write("\nEnter the desired length of the A-array in numbers: ");
                string arrLength = Console.ReadLine();

                bool isNumber = uint.TryParse(arrLength, out adep);

                if (isNumber == true)
                {
                    if (adep == 0)
                    {
                        Console.Write("\nAn array with no values makes no sense... Try again...\n");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.Write("\nThis is not a number or the number is negative! Try again...\n");
                }
            }

            while (true)
            {
                Console.Write("\nEnter the desired length of the B-array in numbers: ");
                string arrLength = Console.ReadLine();

                bool isNumber = uint.TryParse(arrLength, out bdep);

                if (isNumber == true)
                {
                    if (bdep == 0)
                    {
                        Console.Write("\nAn array with no values makes no sense... Try again...\n");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.Write("\nThis is not a number or the number is negative! Try again...\n");
                }
            }

            int[] A = new int[adep];
            int[] B = new int[bdep];

            int minv;
            int maxv;

            while (true)
            {
                Console.Write("\nEnter the desired minimum value of the random in numbers: ");
                string minrand = Console.ReadLine();

                bool isNumber = int.TryParse(minrand, out minv);

                if (isNumber == true)
                {
                    break;
                }
                else
                {
                    Console.Write("\nThis is not a number! Try again...\n");
                }
            }

            while (true)
            {
                Console.Write("\nEnter the desired maximum value of the random in numbers: ");
                string maxrand = Console.ReadLine();

                bool isNumber = int.TryParse(maxrand, out maxv);

                if (isNumber == true)
                {
                    if (maxv >= minv)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("\nMaximum value cannot be less than minimum value! Try again...\n");
                    }
                }
                else
                {
                    Console.Write("\nThis is not a number! Try again...\n");
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                A[i] = GetRandom(minv, maxv);
            }

            Console.Write("\nHow do you want to fill in your second array?\nPress 1 if you want to place suitable values from A-array to B-array at the beginning of the array\nPress 2 if you want to place suitable values from A-array to B-array per their indexes\n");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                int j = 0;
                int sumA2B = 0;

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine($"\nFinal Arrays:\n");

                    if (A.Length >= B.Length)
                    {
                        for (int i = 0; i < B.Length; i++)
                        {
                            if (A[i] <= 888)
                            {
                                B[j] = A[i];
                                j++;
                                sumA2B++;
                            }
                        }

                        for (int i = sumA2B; i < B.Length; i++)
                        {
                            B[i] = GetRandom(minv, maxv);
                        }

                        for (int i = 0; i < B.Length; i++)
                        {
                            Console.WriteLine($"A[{i}]: {A[i]}\t\t| B[{i}]: {B[i]}");
                        }
                        for (int i = B.Length; i < A.Length; i++)
                        {
                            Console.WriteLine($"A[{i}]: {A[i]}\t\t|");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < A.Length; i++)
                        {
                            if (A[i] <= 888)
                            {
                                B[j] = A[i];
                                j++;
                                sumA2B++;
                            }
                        }

                        for (int i = sumA2B; i < B.Length; i++)
                        {
                            B[i] = GetRandom(minv, maxv);
                        }

                        for (int i = 0; i < A.Length; i++)
                        {
                            Console.WriteLine($"A[{i}]: {A[i]}\t\t| B[{i}]: {B[i]}");
                        }

                        for (int i = A.Length; i < B.Length; i++)
                        {
                            Console.WriteLine($"\t\t\t| B[{i}]: {B[i]}");
                        }
                    }

                    break;
                }
                else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {

                    if (A.Length >= B.Length)
                    {
                        for (int i = 0; i < B.Length; i++)
                        {
                            if (A[i] <= 888)
                            {
                                B[i] = A[i];
                            }
                        }

                        for (int i = sumA2B; i < B.Length; i++)
                        {
                            B[i] = GetRandom(minv, maxv);
                        }

                        for (int i = 0; i < B.Length; i++)
                        {
                            Console.WriteLine($"A[{i}]: {A[i]}\t\t| B[{i}]: {B[i]}");
                        }
                        for (int i = B.Length; i < A.Length; i++)
                        {
                            Console.WriteLine($"A[{i}]: {A[i]}\t\t|");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < A.Length; i++)
                        {
                            if (A[i] <= 888)
                            {
                                B[i] = A[i];
                            }
                        }

                        for (int i = sumA2B; i < B.Length; i++)
                        {
                            B[i] = GetRandom(minv, maxv);
                        }

                        for (int i = 0; i < A.Length; i++)
                        {
                            Console.WriteLine($"A[{i}]: {A[i]}\t\t| B[{i}]: {B[i]}");
                        }

                        for (int i = A.Length; i < B.Length; i++)
                        {
                            Console.WriteLine($"\t\t\t| B[{i}]: {B[i]}");
                        }
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Please, make your choice!");
                    continue;
                }
            }
        }
    }
}
