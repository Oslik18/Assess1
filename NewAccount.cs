using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assess1
{
    class NewAccount
    {
        public void NewAccountMenu()
        {
            string firstName;
            string lastName;
            string address;
            string phone;
            string email;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|                CREATE ACCOUNT              |");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|              ENTER THE DETAILS             |");
            Console.WriteLine("|                                            |");
            Console.Write("|     First Name: ");
            int FNCursorT = Console.CursorTop;
            int FNCursorL = Console.CursorLeft;
            Console.Write("                           |");
            Console.Write("\n|     Last Name: ");
            int LNCursorT = Console.CursorTop;
            int LNCursorL = Console.CursorLeft;
            Console.Write("                            |");
            Console.Write("\n|     Address: ");
            int AddCursorT = Console.CursorTop;
            int AddCursorL = Console.CursorLeft;
            Console.Write("                              |");
            Console.Write("\n|     Phone: ");
            int PhoneCursorT = Console.CursorTop;
            int PhoneCursorL = Console.CursorLeft;
            Console.Write("                                |");
            Console.Write("\n|     Email: ");
            int EmailCursorT = Console.CursorTop;
            int EmailCursorL = Console.CursorLeft;
            Console.Write("                                |");
            Console.WriteLine("\n----------------------------------------------\n");
            
            Console.SetCursorPosition(FNCursorL, FNCursorT);
            firstName = Console.ReadLine();

            Console.SetCursorPosition(LNCursorL, LNCursorT);
            lastName = Console.ReadLine();

            Console.SetCursorPosition(AddCursorL, AddCursorT);
            address = Console.ReadLine();

            Console.SetCursorPosition(PhoneCursorL, PhoneCursorT);
            phone = Console.ReadLine();

            Console.SetCursorPosition(EmailCursorL, EmailCursorT);
            email = Console.ReadLine();

            if (!int.TryParse(phone, out int numberPhone) && phone.Length > 10)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nInvalid Phone!... Please Enter ");
                Console.ReadKey();
                NewAccountMenu();
            }

            if (email.Contains("@"))
            {
                if (!email.Contains("gmail.com") && !email.Contains("outlook.com") && !email.Contains("uts.edu.au"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\nInvalid Email!... Please Enter ");
                    Console.ReadKey();
                    NewAccountMenu();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nInvalid Email!... Please Enter ");
                Console.ReadKey();
                NewAccountMenu();
            }

            ConsoleKey response;
            Console.Write("\n  Is the information correct (y/n)? ");
            response = Console.ReadKey(false).Key;
            Console.ReadKey();

            if (response == ConsoleKey.Y)
            {
                AddAcc(firstName, lastName, address, phone, email);
            }
            else
            {
                NewAccountMenu();
            }
            
        }

        void AddAcc(string firstName, string lastName, string address, string phone, string email)
        {
            string file;
            string path;
            int index;
            int newNum;
            

            path = AppDomain.CurrentDomain.BaseDirectory;
            index = path.IndexOf("\\bin\\Debug\\netcoreapp3.1\\");
            path = path.Substring(0, index + 1) + "Accounts\\";

            string[] files = Directory.GetFiles(path);
            string lastString = files[files.Length-1];
            file = lastString.Remove(0, lastString.LastIndexOf("\\") + 1);
            file = file.Remove(file.LastIndexOf("."));
            newNum = Convert.ToInt32(file) + 1;

            

            using (StreamWriter newCl = new StreamWriter(path + newNum + ".txt", true))
            {
                newCl.WriteLine("First Name| " + firstName);
                newCl.WriteLine("Last Name| " + lastName);
                newCl.WriteLine("Address| " + address);
                newCl.WriteLine("Phone| " + phone);
                newCl.WriteLine("Email| " + email);
                newCl.WriteLine("AccountNo| " + newNum);
                newCl.WriteLine("Balance| 0");
                newCl.Close();
            }
            
            

            Console.WriteLine("\n\n\nAccount Created! Details will be provided via email.");
            Console.WriteLine("\nAccount number is " + newNum);
            Console.ReadKey();
            MainMenu mainmenu = new MainMenu();
            mainmenu.MainMenuMenu();
        }

    }

}
