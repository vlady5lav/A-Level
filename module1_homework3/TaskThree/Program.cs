using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TaskThree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:\n");

            string[] words = StringChecker().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            _ = Reverser(words);

            _ = Capitalizer(words);

            _ = Replacer(words);

            ResultString(words);

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

        public static string StringBuild(char ch)
        {
            StringBuilder sb = new (string.Empty);
            return sb.Append(ch).ToString();
        }

        public static string StringChecker()
        {
            while (true)
            {
                string str = Console.ReadLine().Trim();

                string s = string.Empty;

                for (int i = 0; i < str.Length; i++)
                {
                    if (char.IsDigit(str[i]) == false)
                    {
                        s += StringBuild(str[i]);
                    }
                }

                if (string.IsNullOrWhiteSpace(str) == false)
                {
                    return Regex.Replace(s, @"\s+", " ");
                }
                else
                {
                    Console.WriteLine("Enter any letter, please!\n");
                }
            }
        }

        public static string[] Reverser(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (i % 2 == 0)
                {
                    string s = string.Empty;

                    foreach (char c in words[i])
                    {
                        s = StringBuild(c) + s;
                    }

                    words[i] = s;
                }
            }

            return words;
        }

        public static string[] Capitalizer(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim().ToLower();

                words[i] = char.ToUpper(words[i][0]) + words[i][1..];
            }

            return words;
        }

        public static string[] Replacer(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i][0..1].Replace("P", "S", StringComparison.InvariantCultureIgnoreCase) + words[i][1..];

                words[i] = words[i][0..^1] + words[i][^1..].Replace("N", "O", StringComparison.InvariantCultureIgnoreCase);
            }

            return words;
        }

        public static void ResultString(string[] words)
        {
            Console.WriteLine("\nResult:\n");

            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write($"{words[i]}");
                }
                else
                {
                    Console.Write($" {words[i]}");
                }
            }

            Console.WriteLine(string.Empty);
        }
    }
}
