using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assess1
{
    class Withdrawal
    {
        public void WithdrawalMenu()
        {
            string accNumber;
            int amount;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|                 WITHDRAW                   |");
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
            Console.Write("                                 |");
            Console.WriteLine("\n----------------------------------------------\n");

            Console.SetCursorPosition(AccCursorL, AccCursorT);
            accNumber = Console.ReadLine();

            if (!int.TryParse(accNumber, out int accNum))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nInvalid account number!...");
                Console.ReadKey();
                WithdrawalMenu();
            }

            SearchAcc(accNum);

            Console.SetCursorPosition(AmmCursorL, AmmCursorT);
            amount = Convert.ToInt32(Console.ReadLine()) * (-1);
            Deposit withdr = new Deposit();
            withdr.DepositAdd(accNum, amount, "Withdraw");
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
                    WithdrawalMenu();
                }
                else
                {
                    MainMenu mainmenu = new MainMenu();
                    mainmenu.MainMenuMenu();
                }

            }
            return;
        }
    }
}
