using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assess1
{
    class SearchAccount
    {

        public void SearchAccountMenu()
        {
            string accNumber;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|               SEARCH ACCOUNT               |");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|             ENTER THE DETAILS              |");
            Console.WriteLine("|                                            |");
                Console.Write("|     Account Number: ");
            int AccCursorT = Console.CursorTop;
            int AccCursorL = Console.CursorLeft;
            Console.Write("                       |");
            Console.WriteLine("\n----------------------------------------------\n");

            Console.SetCursorPosition(AccCursorL, AccCursorT);
            accNumber = Console.ReadLine();

            if(!int.TryParse(accNumber, out int accNum))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nInvalid account number!...");
                Console.ReadKey();
                SearchAccountMenu();
            }

            SearchAcc(accNum);
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
                Console.WriteLine("\n\nAccount found!");
                PrintInfo(accNum);
                ConsoleKey response;
                Console.Write("\n\nCheck another account (y/n)? ");
                response = Console.ReadKey(false).Key;
                Console.ReadKey();

                if (response == ConsoleKey.Y)
                {
                    SearchAccountMenu();
                }
                else
                {
                    MainMenu mainmenu = new MainMenu();
                    mainmenu.MainMenuMenu();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nAccount number " + accNum + " is invalid");
                Console.ReadKey();
                SearchAccountMenu();
            }
        }

        public void PrintInfo(int accNumber)
        {
            string path;
            int index;

            path = AppDomain.CurrentDomain.BaseDirectory;
            index = path.IndexOf("\\bin\\Debug\\netcoreapp3.1\\");
            path = path.Substring(0, index + 1) + "Accounts\\" + accNumber + ".txt";

            string[] file = File.ReadAllLines(path);
            Console.WriteLine("\n\n----------------------------------------------");
            Console.WriteLine("               ACCAUNT DETAILS                ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("   " + file[5].Replace('|', ':'));
            Console.WriteLine("   " + file[6].Replace('|', ':'));
            Console.WriteLine("   " + file[0].Replace('|', ':'));
            Console.WriteLine("   " + file[1].Replace('|', ':'));
            Console.WriteLine("   " + file[2].Replace('|', ':'));
            Console.WriteLine("   " + file[3].Replace('|', ':'));
            Console.WriteLine("   " + file[4].Replace('|', ':'));
            Console.WriteLine("\n----------------------------------------------\n");

            return;
        }
    }
}
