using System;

namespace Functional_Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n\n\t\t Welcome to our Casino! ");
            Console.WriteLine("\n\tPress any key to play!");
            Console.ReadKey();
            Console.Clear();
            Random rnd = new Random();
            ulong balance = 1000;
            ulong bet;
            PlayGame(rnd, ref balance);
        }
        private static void Bet(ulong balance, out ulong bet)
        {
            bet = 0;
            ulong prebet;
            bool betmade = true;
            bool choice;
            char answer;
            Console.WriteLine("\t\tMake your bet!");
            while (betmade)
            {
                try
                {
                    prebet = ulong.Parse(Console.ReadLine());
                    if (prebet > 0 && prebet <= balance && prebet+bet <= balance)
                    {
                        bet += prebet;
                        betmade = false;
                    }
                    else if (prebet > balance || (prebet+bet) > balance)
                        Console.WriteLine("You don't have money for this bet, try again!");
                    else
                        Console.WriteLine("Your bet is zero, try again!");
                }
                catch
                {
                    Console.WriteLine("An input error! Try again!");
                }
                if (betmade == false && bet < balance && bet < balance)
                {
                    do
                    {
                        Console.WriteLine("Do you want to add your bet? (y - yes; n - no)");
                        choice = char.TryParse(Console.ReadLine(), out answer);
                        if (answer == char.Parse("y"))
                        {
                            choice = false;
                            betmade = true;
                            Console.WriteLine("\t\tMake your bet!");
                        }
                        else if (answer == char.Parse("n"))
                        {
                            choice = false;
                            betmade = false;
                            Console.WriteLine("Your bet equal " + bet + "$");
                        }
                        else
                        {
                            Console.WriteLine("Please enter only y or n");
                            choice = true;
                        }
                    }
                    while (choice);
                }
            }
        }

        private static void PlayGame(Random rnd, ref ulong balance)
        {
            bool choice;
            bool play = true;
            ulong bet;
            char answer;
            do
            {
                int color = rnd.Next() % 2;
                Console.WriteLine("\t\t\t Your balance: " + balance + "$");
                Bet(balance, out bet);
                do
                {
                    Console.WriteLine("Enter B (for Black) or R (for Red)");
                    choice = char.TryParse(Console.ReadLine(), out answer);
                    if (answer == char.Parse("B"))
                    {
                        choice = false;
                        if (color == 0)
                        {
                            balance += bet;
                            Console.WriteLine("You win!\n+" + bet + "$");
                        }
                        else
                        {
                            balance -= bet;
                            Console.WriteLine("You lose!\n-" + bet + "$");
                        }
                    }
                    else if (answer == char.Parse("R"))
                    {
                        choice = false;
                        if (color == 1)
                        {
                            balance += bet;
                            Console.WriteLine("You win!\n+" + bet + "$");
                        }
                        else
                        {
                            balance -= bet;
                            Console.WriteLine("You lose!\n - " + bet + "$");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter only B or R");
                        choice = true;
                    }
                }
                while (choice);
                Console.Write("Roulette rolled ");
                if (color == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("BLACK");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("RED");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nYour balance: " + balance);
                if (balance > 0)
                {
                    do
                    {
                        Console.WriteLine("Do you want to continue? (y - yes; n - no)");
                        choice = char.TryParse(Console.ReadLine(), out answer);
                        if (answer == char.Parse("y"))
                        {
                            choice = false;
                            play = true;
                            Console.WriteLine("Make you bet");
                        }
                        else if (answer == char.Parse("n"))
                        {
                            choice = false;
                            play = false;
                        }
                        else
                        {
                            Console.WriteLine("Please enter only y or n");
                            choice = true;
                        }
                    }
                    while (choice);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("We are so sorry, but you can't play anymore, you lost all your money.");
                    play = false;
                }
            } while (play);
            Console.WriteLine("Thanks for the game!\nHope see you soon again!");
        }
    }
}
