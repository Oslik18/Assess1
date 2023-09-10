using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assess1
{
    class Statement
    {
        public void StatementMenu()
        {
            string accNumber;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|                 STATEMENT                  |");
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

            if (!int.TryParse(accNumber, out int accNum))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nInvalid account number!...");
                Console.ReadKey();
                StatementMenu();
            }
            StatAcc(accNum);
        }
        void StatAcc(int accNum)
        {
            string path;
            int index;


            path = AppDomain.CurrentDomain.BaseDirectory;
            index = path.IndexOf("\\bin\\Debug\\netcoreapp3.1\\");
            path = path.Substring(0, index + 1) + "Accounts\\";

            string[] files = Directory.GetFiles(path, accNum + ".txt");
            if (files.Length > 0)
            {
                Console.WriteLine("\n\nAccount found! This Statement is Displayed below...");
                PrintStatement(accNum);
                ConsoleKey response;
                Console.Write("\n\nEmail statement (y/n)? ");
                response = Console.ReadKey(false).Key;
                Console.ReadKey();

                if (response == ConsoleKey.Y)
                {
                    Console.WriteLine("\nEmail sent successfully");
                    Console.ReadKey();
                    MainMenu mainmenu = new MainMenu();
                    mainmenu.MainMenuMenu();
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
                StatementMenu();
            }
        }

        void PrintStatement(int accNum)
        {
            string path;
            int index;

            path = AppDomain.CurrentDomain.BaseDirectory;
            index = path.IndexOf("\\bin\\Debug\\netcoreapp3.1\\");
            path = path.Substring(0, index + 1) + "Accounts\\" + accNum + ".txt";

            string[] file = File.ReadAllLines(path);
            Console.WriteLine("\n\n----------------------------------------------");
            Console.WriteLine("             SIMPLE BANKING SYSTEM            ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("    Account Statement");
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
