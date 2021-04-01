using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class BorrowData
    {
        private int id_borrow;
        private string name;
        private string book_name;
        private string address;
        private string no_telp;
        private DateTime date_of_borrow;
        private DateTime date_of_return;

        public int BorrowID
        {
            get { return id_borrow; }
            set { id_borrow = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string BookName
        {
            get { return book_name; }
            set { book_name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string NoTelp
        {
            get { return no_telp; }
            set { no_telp = value; }
        }
        public DateTime DateOfBorrow
        {
            get { return date_of_borrow; }
            set { date_of_borrow = value; }
        }

        public DateTime DateOfReturn
        {
            get { return date_of_return; }
            set { date_of_return = value; }
        }

    }
}
