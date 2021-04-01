using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement;

namespace LibraryManagement
{
    class BookOperation
    {
        private BookData bookData = new BookData();
        private ViewBook viewBook = new ViewBook();


        public void createFileBook()
        {
            Console.Clear();
            FileStream fileStream = null;
            if (!File.Exists(Constanta.Configuration.filePath))
            {
                Console.WriteLine("Success Create File.");
                
            }
            else
            {
                Console.WriteLine("File Already exist");
                
            }
            viewBook.BookMenu();
           
        }

        public void addBook()
        {
            Console.Clear();
            Console.WriteLine("Enter Data Book");
            Console.WriteLine("ID Book ");
            bookData.BookId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name Book ");
            bookData.NameBook = Console.ReadLine();
            Console.WriteLine("Author ");
            bookData.Author = Console.ReadLine();
            Console.WriteLine("Publisher ");
            bookData.Publisher = Console.ReadLine();
            Console.WriteLine("Date Of Issue ");
            bookData.DateOfIssue = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Are You sure to Asve data? (Y/N)");
            string confirm = Console.ReadLine();
            if (confirm.ToUpper() == "Y")
            {
                writeToFile(bookData);
            }
            viewBook.BookMenu();
        }

        public void readBook()
        {
            Console.Clear();
            if (File.Exists(Constanta.Configuration.filePath))
            {
                using(StreamReader streamReader = new StreamReader(Constanta.Configuration.filePath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
            viewBook.BookMenu();
        }

        public void readByIdBook()
        {
            Console.Clear();
            Console.WriteLine("Search by id");
            int id = Convert.ToInt32(Console.ReadLine());

            List<BookData> books = new List<BookData>();

            if (File.Exists(Constanta.Configuration.filePath))
            {
                string allText;
                FileStream fileStream = new FileStream(Constanta.Configuration.filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    allText = streamReader.ReadToEnd();
                }

                string[] rows = allText.Split(Constanta.Configuration.rowDelimeter);
                foreach(string row in rows)
                {
                    if(row.Length > 0 && !string.IsNullOrWhiteSpace(row.ToString()))
                    {
                        string[] columns = row.Split(Constanta.Configuration.columnDelimeter);
                        BookData bookData = new BookData();
                        bookData.BookId = Convert.ToInt32(columns[0]);
                        bookData.NameBook = columns[1];
                        bookData.Author = columns[2];
                        bookData.Publisher = columns[3];
                        bookData.DateOfIssue = Convert.ToDateTime(columns[4].Replace(";", ""));

                        books.Add(bookData);
                    }
                }

                bool isFound = false;
                foreach(BookData book in books)
                {
                    if(id == book.BookId)
                    {
                        Console.WriteLine("Book Id : {0}", book.BookId);
                        Console.WriteLine("Name Book : {0}", book.NameBook);
                        Console.WriteLine("Author : {0}", book.Author);
                        Console.WriteLine("Publisher : {0}", book.Publisher);
                        Console.WriteLine("Date of Issue : {0}", book.DateOfIssue);
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Book Is Not Found");
                }
            }
            viewBook.BookMenu();
        }

        public void searchByTitleBook()
        {
            Console.Clear();
            Console.WriteLine("Search by Title Book");
            string title = Console.ReadLine();

            List<BookData> books = new List<BookData>();

            if (File.Exists(Constanta.Configuration.filePath))
            {
                string allText;
                FileStream fileStream = new FileStream(Constanta.Configuration.filePath, FileMode.Open, FileAccess.Read);
                using(StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    allText = streamReader.ReadToEnd();
                }

                string[] rows = allText.Split(Constanta.Configuration.rowDelimeter);
                foreach(string row in rows)
                {
                    if(row.Length > 0 && !string.IsNullOrWhiteSpace(row.ToString()))
                    {
                        string[] columns = row.Split(Constanta.Configuration.columnDelimeter);
                        BookData bookData = new BookData();
                        bookData.BookId = Convert.ToInt32(columns[0]);
                        bookData.NameBook = columns[1];
                        bookData.Author = columns[2];
                        bookData.Publisher = columns[3];
                        bookData.DateOfIssue = Convert.ToDateTime(columns[4].Replace(";", ""));

                        books.Add(bookData);
                    }
                }

                bool isFound = false;
                foreach(BookData book in books)
                {
                    if (book.NameBook.Contains(title))
                    {
                        Console.WriteLine("List of Book With Title Contains {0}.", title);
                        Console.WriteLine("Book Id : {0}", book.BookId);
                        Console.WriteLine("Name Book : {0}", book.NameBook);
                        Console.WriteLine("Author L {0}", book.Author);
                        Console.WriteLine("Publisher : {0}", book.Publisher);
                        Console.WriteLine("Date Of Issue : {0}", book.DateOfIssue);
                        isFound = true;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Book not Found");
                }
            }
            viewBook.BookMenu();
        }

        public void updateByIdBook()
        {
            Console.Clear();
            Console.WriteLine("Enter Id ");
            int id = Convert.ToInt32(Console.ReadLine());

            List<BookData> books = new List<BookData>();

            if (File.Exists(Constanta.Configuration.filePath))
            {
                string allText;
                FileStream fileStream = new FileStream(Constanta.Configuration.filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    allText = streamReader.ReadToEnd();
                }

                string[] rows = allText.Split(Constanta.Configuration.rowDelimeter);
                foreach(string row in rows)
                {
                    if(row.Length > 0 && !string.IsNullOrWhiteSpace(row.ToString()))
                    {
                        string[] columns = row.Split(Constanta.Configuration.columnDelimeter);
                        BookData bookData = new BookData();
                        bookData.BookId = Convert.ToInt32(columns[0]);
                        bookData.NameBook = columns[1];
                        bookData.Author = columns[2];
                        bookData.Publisher = columns[3];
                        bookData.DateOfIssue = Convert.ToDateTime(columns[4].Replace(";", ""));

                        books.Add(bookData);
                    }
                }

                bool isFound = false;
                foreach (BookData book in books)
                {
                    if(id == book.BookId)
                    {
                        Console.WriteLine("Book Id : {0}", book.BookId);
                        Console.WriteLine("Enter Id : ");
                        book.BookId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Name Book :{0}", book.NameBook);
                        Console.WriteLine("Enter Name Book : ");
                        book.NameBook = Console.ReadLine();

                        Console.WriteLine("Author :{0}", book.Author);
                        Console.WriteLine("Author : ");
                        book.Author = Console.ReadLine();

                        Console.WriteLine("Publisher :{0}", book.Publisher);
                        Console.WriteLine("Publisher : ");
                        book.Publisher = Console.ReadLine();

                        Console.WriteLine("Date of issue : {0}", book.DateOfIssue);
                        Console.WriteLine("Enter Date of issue : ");
                        book.DateOfIssue = Convert.ToDateTime(Console.ReadLine());

                        isFound = true;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("BookData Not Found");
                }

                updateToFile(books);
            }

            viewBook.BookMenu();
        }

        private void writeToFile(BookData bookData)
        {
            if (File.Exists(Constanta.Configuration.filePath))
            {
                using(StreamWriter streamWriter = new StreamWriter(Constanta.Configuration.filePath, true))
                {
                    streamWriter.Write(streamWriter.NewLine);
                    streamWriter.Write("{0}| ", bookData.BookId);
                    streamWriter.Write("{0}| ", bookData.NameBook);
                    streamWriter.Write("{0}| ", bookData.Author);
                    streamWriter.Write("{0}| ", bookData.Publisher);
                    streamWriter.Write("{0}; ", bookData.DateOfIssue);
                }
            }

            else
            {
                Console.WriteLine("File doesn't exist.");
            }
        }

        private void updateToFile(List<BookData> books)
        {
            if (File.Exists(Constanta.Configuration.filePath))
            {
                using (StreamWriter streamWriter = new StreamWriter(Constanta.Configuration.filePath))
                {
                    foreach(BookData book in books)
                    {
                        streamWriter.Write("{0}| ", book.BookId);
                        streamWriter.Write("{0}| ", book.NameBook);
                        streamWriter.Write("{0}| ", book.Author);
                        streamWriter.Write("{0}| ", book.Publisher);
                        streamWriter.Write("{0}; ", book.DateOfIssue);
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist.");
            }
        }
       

    }
}
