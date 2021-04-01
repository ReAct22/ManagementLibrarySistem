using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class LoginPage
    {
        public string username = "Andrean";
        string password;
        Dahsboard Dashboard = new Dahsboard();
       public void getLogin()
        {
            Console.Clear();
            Console.WriteLine("Login Admin");
            Console.WriteLine("___________");
            Console.WriteLine("Username : ");
            username = Console.ReadLine();
            Console.WriteLine("Password : ");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            if (username == "Andrean")
            {
                Dashboard.Display();
            }
            else
            {
                Console.WriteLine("Username Dan Password Anda Salah Silahkan Ulangin kemblai");
                Console.ReadLine();
            }
        }
    }
}
