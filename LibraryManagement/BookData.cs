using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class BookData
    {
        private int book_id;
        private string name_book;
        private string author;
        private string publisher;
        private DateTime date_of_issue;

        public int BookId
        {
            get { return book_id; }
            set { book_id = value; }
        }

        public string NameBook
        {
            get { return name_book; }
            set { name_book = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public DateTime DateOfIssue
        {
            get { return date_of_issue; }
            set { date_of_issue = value; }
        }
    }
}
