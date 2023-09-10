using System;
using System.Collections.Generic;
using System.Text;

namespace Assess1
{
    public class MainMenu
    {
        
        public void MainMenuMenu()
        {
            string choice;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|      WELCOME TO SIMPLE BANKING SYSTEM      |");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|    1. Create a new account                 |");
            Console.WriteLine("|    2. Search for an account                |");
            Console.WriteLine("|    3. Deposit                              |");
            Console.WriteLine("|    4. Withdraw                             |");
            Console.WriteLine("|    5. A/C statement                        |");
            Console.WriteLine("|    6. Delete account                       |");
            Console.WriteLine("|    7. Exit                                 |");
            Console.WriteLine("----------------------------------------------");
                Console.Write("|    Enter your choice (1-7): ");
            int MenuCursorT = Console.CursorTop;
            int MenuCursorL = Console.CursorLeft;

            Console.Write("               |");
            Console.WriteLine("\n----------------------------------------------\n");

            Console.SetCursorPosition(MenuCursorL, MenuCursorT);
            choice = Console.ReadLine();
            CheckMenu(choice);
        }

        void CheckMenu(string choice)
        {
            
            switch (choice)
            {
                case "1":
                    NewAccount newacc = new NewAccount();
                    newacc.NewAccountMenu();
                    break;
                case "2":
                    SearchAccount searchacc = new SearchAccount();
                    searchacc.SearchAccountMenu();
                    break;
                case "3":
                    Deposit deposit = new Deposit();
                    deposit.DepositMenu();
                    break;
                case "4":
                    Withdrawal withdraw = new Withdrawal();
                    withdraw.WithdrawalMenu();
                    break;
                case "5":
                    Statement statement = new Statement();
                    statement.StatementMenu();
                    break;
                case "6":
                    DeleteAccount delete = new DeleteAccount();
                    delete.DeleteMenu();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    MainMenuMenu();
                    break;
            }

        }
    }
}
