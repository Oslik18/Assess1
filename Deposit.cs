using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assess1
{
    class Deposit
    {
        public void DepositMenu()
        {
            string accNumber;
            int amount;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|                  DEPOSIT                   |");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|             ENTER THE DETAILS              |");
            Console.WriteLine("|                                            |");
            Console.Write("|     Account Number: ");
            int AccCursorT = Console.CursorTop;
            int AccCursorL = Console.CursorLeft;
            Console.Write("                       |");
            Console.Write("\n|     Amount: ");
            int AmmCursorT = Console.CursorTop;
            int AmmCursorL = Console.CursorLeft;
            Console.Write("                               |");
            Console.WriteLine("\n----------------------------------------------\n");

            Console.SetCursorPosition(AccCursorL, AccCursorT);
            accNumber = Console.ReadLine();

            if (!int.TryParse(accNumber, out int accNum))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nInvalid account number!...");
                Console.ReadKey();
                DepositMenu();
            }

            SearchAcc(accNum);

            Console.SetCursorPosition(AmmCursorL, AmmCursorT);
            amount = Convert.ToInt32(Console.ReadLine());

            DepositAdd(accNum, amount, "Deposit");

        }

         void SearchAcc(int accNum)
        {
            string path;
            int index;

            path = AppDomain.CurrentDomain.BaseDirectory;
            index = path.IndexOf("\\bin\\Debug\\netcoreapp3.1\\");
            path = path.Substring(0, index + 1) + "Accounts\\";

            string[] files = Directory.GetFiles(path, accNum + ".txt");
            if (files.Length > 0)
            {
                Console.WriteLine("\n\nAccount found! Enter Amount");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\n\nAccount number not find!");
                ConsoleKey response;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\n\nRetry (y/n)? ");
                response = Console.ReadKey(false).Key;
                Console.ReadKey();

                if (response == ConsoleKey.Y)
                {
                    DepositMenu();
                }
                else
                {
                    MainMenu mainmenu = new MainMenu();
                    mainmenu.MainMenuMenu();
                }

            }
            return;
        }

        public void DepositAdd(int accNum, int amount, string operation)
        {
            string path;
            int index;
            string balance;

            path = AppDomain.CurrentDomain.BaseDirectory;
            index = path.IndexOf("\\bin\\Debug\\netcoreapp3.1\\");
            path = path.Substring(0, index + 1) + "Accounts\\" + accNum + ".txt";

            string[] file = File.ReadAllLines(path);
            balance = file[6];

            int sum = Convert.ToInt32(balance.Substring(8)) + amount;

            string[] lines = new string[file.Length + 1]; ;

            for (int i = 0; i < file.Length; i++)
            {
                if (i == 6)
                {
                    lines[i] = "Balance|" + sum;
                }
                else
                {
                    lines[i] = file[i];
                }
            }

            if (amount < 0)
            {
                amount *= -1;
            }

            lines[file.Length] = DateTime.Today.ToShortDateString() + "|" + operation + "|" + amount + "|" + sum;

            File.WriteAllLines(path, lines);

            Console.WriteLine("\n\n\n" + operation + "  successfull!");
            Console.ReadKey();
            MainMenu mainmenu = new MainMenu();
            mainmenu.MainMenuMenu();
        }
    }
}
