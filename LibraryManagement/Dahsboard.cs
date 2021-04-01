using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Dahsboard
    {
        private ViewBook viewbook = new ViewBook();
        private ViewBorrow viewBorrow = new ViewBorrow();
        public void Display()
        {
            
            int pilih;
            LoginPage LoginPage = new LoginPage();
            Console.Clear();
            Console.WriteLine("Welcome " + LoginPage.username);
            Console.WriteLine("______________");
            Console.WriteLine("1. Book Data");
            Console.WriteLine("2. Borrower Data");
            Console.WriteLine("3. LogOut");
            pilih = Convert.ToInt32(Console.ReadLine());
            
            switch (pilih)
            {
                case 1:
                    Console.Clear();
                    viewbook.BookMenu();
                    break;
                case 2:
                    Console.Clear();
                    viewBorrow.viewBorrow();
                    break;
                case 3:
                    LoginPage.getLogin();
                    break;
            }
        }
    }
}
