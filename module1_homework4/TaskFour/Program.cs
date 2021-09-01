using System;

namespace TaskFour
{
    /// <summary>
    /// Class Program - the beginning of our application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Method Main - entry point to the action.
        /// </summary>
        /// <param name="args">Arguments for the Main method from the console.</param>
        public static void Main(string[] args)
        {
            int[] intArr = IntArray();

            char[] charArr = NumsToLetters(intArr);

            OddEvenArrays(intArr, charArr, out uint oddCount, out uint evenCount, out uint oddUpper, out uint evenUpper, out char[] oddArr, out char[] evenArr);

            FinalResult(intArr, charArr, oddArr, evenArr, oddCount, evenCount, oddUpper, evenUpper);

            Console.ReadKey();

            Console.WriteLine("\nDo you want to try again? [Y]es/[N]o");

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

        /// <summary>
        /// Get a random number with specifying minimum and maximum value.
        /// </summary>
        /// <param name="minval">Minimum random value.</param>
        /// <param name="maxval">Maximum random value.</param>
        /// <returns>A random number between minimum and maximum value.</returns>
        public static int GetRandom(int minval, int maxval)
        {
            Random randomized = new Random();

            int rnd = randomized.Next(minval, maxval);

            return rnd;
        }

        /// <summary>
        /// Creates an array with customizable size and random numbers from 1 to 26 inclusively in it.
        /// </summary>
        /// <returns>An array with custom size and random numbers from 1 to 26 inclusively in it.</returns>
        public static int[] IntArray()
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
                    Console.Write("\nThe number is negative or too large, or it is not a number at all! Please, try again...\n");
                }
            }

            int[] intArr = new int[size];

            for (int i = 0; i < intArr.Length; i++)
            {
                intArr[i] = GetRandom(1, 27);
            }

            return intArr;
        }

        /// <summary>
        /// Converts numbers to english letters by their consecutive number in the alphabet.
        /// </summary>
        /// <param name="intArr">Input number array.</param>
        /// <returns>A char array obtained by converting numbers to english letters by their consecutive number in the alphabet.</returns>
        public static char[] NumsToLetters(int[] intArr)
        {
            char[] charArr = new char[intArr.Length];

            char[] upperArr = new char[] { 'a', 'd', 'e', 'h', 'i', 'j' };

            for (int i = 0; i < charArr.Length; i++)
            {
                charArr[i] = (char)(intArr[i] + 96);

                for (int j = 0; j < upperArr.Length; j++)
                {
                    if (charArr[i] == upperArr[j])
                    {
                        charArr[i] = char.ToUpper(charArr[i]);
                    }
                }
            }

            return charArr;
        }

        /// <summary>
        /// Creates 2 new arrays from the input number array - first for an odd numbers and second for an even numbers. Calculates number of odd and even values in the input number array. Calculates number of uppers in new odd and even char arrays.
        /// </summary>
        /// <param name="intArr">Input number array.</param>
        /// <param name="charArr">Char array obtained by converting numbers to english letters by their consecutive number in the alphabet.</param>
        /// <param name="oddCount">Number of odd values in the input number array.</param>
        /// <param name="evenCount">Number of even values in the input number array.</param>
        /// <param name="oddUpper">Number of uppers in odd char array.</param>
        /// <param name="evenUpper">Number of uppers in even char array.</param>
        /// <param name="oddArr">Char array with odd values from numbers array.</param>
        /// <param name="evenArr">Char array with even values from numbers array.</param>
        /// <returns>Number of odd values. Number of even values. Char array with odd values. Char array with even values. Number of uppers in the odd char array. Number of uppers in the even char array.</returns>
        public static (uint oddCount, uint evenCount, uint oddUpper, uint evenUpper, char[] oddArr, char[] evenArr) OddEvenArrays(int[] intArr, char[] charArr, out uint oddCount, out uint evenCount, out uint oddUpper, out uint evenUpper, out char[] oddArr, out char[] evenArr)
        {
            evenCount = 0;
            oddCount = 0;

            oddUpper = 0;
            evenUpper = 0;

            foreach (int num in intArr)
            {
                if (num % 2 == 0)
                {
                    evenCount++;
                }
            }

            oddCount = (uint)(intArr.Length - evenCount);

            evenArr = new char[evenCount];
            oddArr = new char[oddCount];

            int valCount = 0;
            int indexEven = 0;
            int indexOdd = 0;

            foreach (int num in intArr)
            {
                if (num % 2 == 0)
                {
                    evenArr[indexEven] = charArr[valCount];
                    indexEven++;
                }
                else
                {
                    oddArr[indexOdd] = charArr[valCount];
                    indexOdd++;
                }

                valCount++;
            }

            for (int i = 0; i < oddArr.Length; i++)
            {
                if (char.IsUpper(oddArr[i]))
                {
                    oddUpper++;
                }
            }

            for (int i = 0; i < evenArr.Length; i++)
            {
                if (char.IsUpper(evenArr[i]))
                {
                    evenUpper++;
                }
            }

            return (evenCount, oddCount, oddUpper, evenUpper, oddArr, evenArr);
        }

        /// <summary>
        /// Prints to the console the values of: input number array, char array converted from the number array, char array of odd values, char array of even values, number of odd values, number of even values, number of uppers in the odd char array, number of uppers in the even char array.
        /// </summary>
        /// <param name="intArr">Input number array.</param>
        /// <param name="charArr">Char array obtained by converting numbers to english letters by their consecutive number in the alphabet.</param>
        /// <param name="oddArr">Char array with odd values from numbers array.</param>
        /// <param name="evenArr">Char array with even values from numbers array.</param>
        /// <param name="oddCount">Number of odd values in the input number array.</param>
        /// <param name="evenCount">Number of even values in the input number array.</param>
        /// <param name="oddUpper">Number of uppers in odd char array.</param>
        /// <param name="evenUpper">Number of uppers in even char array.</param>
        public static void FinalResult(int[] intArr, char[] charArr, char[] oddArr, char[] evenArr, uint oddCount, uint evenCount, uint oddUpper, uint evenUpper)
        {
            if (oddCount > evenCount)
            {
                Console.WriteLine($"\nThere is more Odd values - {oddCount} vs {evenCount} Even values!");
            }
            else if (oddCount < evenCount)
            {
                Console.WriteLine($"\nThere is more Even values - {evenCount} vs {oddCount} Odd values!");
            }
            else
            {
                Console.WriteLine($"\nThere is the same amount of odd and even values - {oddCount} each!");
            }

            Console.Write($"\nNumbers Array: ");

            for (int i = 0; i < intArr.Length; i++)
            {
                if (i < intArr.Length - 1)
                {
                    Console.Write($"{intArr[i]} ");
                }
                else
                {
                    Console.WriteLine($"{intArr[i]}");
                }
            }

            Console.Write($"\nChars Array: ");

            for (int i = 0; i < charArr.Length; i++)
            {
                if (i < charArr.Length - 1)
                {
                    Console.Write($"{charArr[i]} ");
                }
                else
                {
                    Console.WriteLine($"{charArr[i]}");
                }
            }

            if (oddCount != 0)
            {
                Console.Write($"\nOdd Array: ");

                for (int i = 0; i < oddArr.Length; i++)
                {
                    if (i < oddArr.Length - 1)
                    {
                        Console.Write($"{oddArr[i]} ");
                    }
                    else
                    {
                        Console.Write($"{oddArr[i]}");
                    }
                }
            }
            else
            {
                Console.Write($"\nOdd Array is Empty!");
            }

            if (evenCount != 0)
            {
                Console.Write($"\n\nEven Array: ");

                for (int i = 0; i < evenArr.Length; i++)
                {
                    if (i < evenArr.Length - 1)
                    {
                        Console.Write($"{evenArr[i]} ");
                    }
                    else
                    {
                        Console.WriteLine($"{evenArr[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"\n\nEven Array is Empty!");
            }

            if (oddUpper > evenUpper)
            {
                Console.WriteLine($"\nThere is more upper chars in Odd Array - {oddUpper} vs {evenUpper} in Even Array!");
            }
            else if (oddUpper < evenUpper)
            {
                Console.WriteLine($"\nThere is more upper chars in Even Array - {evenUpper} vs {oddUpper} in Odd Array!");
            }
            else
            {
                Console.WriteLine($"\nBoth Arrays have the same amount of upper chars - {oddUpper}!");
            }
        }
    }
}
