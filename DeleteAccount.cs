using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assess1
{
    class DeleteAccount
    {
        public void DeleteMenu()
        {
            string accNumber;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|             DELETE AN ACCOUNT              |");
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
                DeleteMenu();
            }

            DelAcc(accNum);

        }

        void DelAcc(int accNum)
        {
            string path;
            int index;


            path = AppDomain.CurrentDomain.BaseDirectory;
            index = path.IndexOf("\\bin\\Debug\\netcoreapp3.1\\");
            path = path.Substring(0, index + 1) + "Accounts\\";

            string[] files = Directory.GetFiles(path, accNum + ".txt");
            if (files.Length > 0)
            {
                Console.WriteLine("\n\nAccount found! Delails displeyed below...");

                SearchAccount searchacc = new SearchAccount();
                searchacc.PrintInfo(accNum);
                

                ConsoleKey response;
                Console.Write("\n\nDelete (y/n)? ");
                response = Console.ReadKey(false).Key;
                Console.ReadKey();

                if (response == ConsoleKey.Y)
                {
                    FileInfo fileInf = new FileInfo(path + accNum + ".txt");
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();
                    }
                    Console.WriteLine("\nAccount Deleted!...");

                }

                Console.ReadKey();
                MainMenu mainmenu = new MainMenu();
                mainmenu.MainMenuMenu();                   
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nAccount number " + accNum + " is invalid");
                Console.ReadKey();
                DeleteMenu();
            }



        }
    }
}
