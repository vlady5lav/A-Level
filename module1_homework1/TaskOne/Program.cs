using System;

namespace TaskOne
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nHello! This program will show you how many years remain till your new life ;-)");

            Life();

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

        public static void Life()
        {
            Console.Write("\nEnter your First Name: ");
            string FirstName = Console.ReadLine();

            Console.Write("\nEnter your Last Name: ");
            string LastName = Console.ReadLine();

            uint age;

            while (true)
            {
                Console.Write("\nEnter your age in numbers: ");
                string inp = Console.ReadLine();

                bool isNumber = UInt32.TryParse(inp, out age);

                if (isNumber == true)
                {
                    break;
                }
                else
                {
                    Console.Write("\nThis is not a number or number is negative! Try again...\n");
                }
            }

            int ToNewLife = 40 - (int)age;

            if (age < 40)
            {
                Console.Write($"\nKeep it up, {FirstName} {LastName}!\nYou're {ToNewLife} years away from your new life!\n");
            }
            else if (age > 40)
            {
                Console.Write($"\nCongratulations, {FirstName} {LastName}...\nYou've already been living your new life for {Math.Abs(ToNewLife)} years!\n");
            }
            else
            {
                Console.Write($"\nAwesome, {FirstName} {LastName}!\nYou've just begun your journey in your new life!\n");
            }

            Console.ReadKey();
        }
    }
}
