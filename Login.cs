using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assess1
{
    public class Login
    {
        
        
        public void LogMenu()
        {
            string UserName;
            string Password = "";
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|      WELCOME TO SIMPLE BANKING SYSTEM      |");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|               LOGIN TO START               |");
            Console.WriteLine("|                                            |");
            Console.Write("|     User Name: ");
            int LogCursorT = Console.CursorTop;
            int LogCursorL = Console.CursorLeft;
            
            Console.Write("                            |");
            Console.Write("\n|     Password: ");
            int PassCursorT = Console.CursorTop;
            int PassCursorL = Console.CursorLeft;
            Console.Write("                             |");
            Console.WriteLine("\n----------------------------------------------\n");

            Console.SetCursorPosition(LogCursorL, LogCursorT);
            UserName = Console.ReadLine();

            Console.SetCursorPosition(PassCursorL, PassCursorT);

            do
            {
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                if (keyPress.Key != ConsoleKey.Backspace  && keyPress.Key != ConsoleKey.Enter)
                {
                    Password += keyPress.KeyChar;
                    Console.Write("*");
                    
                }
                else
                {
                    if (keyPress.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (keyPress.Key == ConsoleKey.Backspace && Password.Length > 0)
                    {
                        Console.Write("\b \b");
                        Password = Password.Remove(Password.Length - 1);
                    }
                }
            } while (true);


            CheckLogin(UserName, Password);
        }

        void CheckLogin(string UName, string Pass)
        {
            string s;
            string file;
            int index;
            int find = 0;
            string login = UName + "|" + Pass;
            
            file = AppDomain.CurrentDomain.BaseDirectory;
            index = file.IndexOf("\\bin\\Debug\\netcoreapp3.1\\");
            file = file.Substring(0, index + 1) + "login.txt";

            StreamReader path = new StreamReader(file);
            while ((s = path.ReadLine()) != null)
            {
                if (login == s)
                {
                    find = 1;
                }
            }
            path.Close();

            if (find == 1)
            {
                Console.WriteLine("\n\nValid credentials!... Please Enter ");
                Console.ReadKey();
                MainMenu mainmenu = new MainMenu();
                mainmenu.MainMenuMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nInvalid credentials!... Please Enter ");
                Console.ReadKey();
                LogMenu();
            }
        }
    }
}
