using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement;

namespace LibraryManagement
{
    class BorrowOperation
    {
        private BorrowData borrowData = new BorrowData();
        private ViewBorrow viewBorrow = new ViewBorrow();

        public void creatFileBorrow()
        {
            Console.Clear();
            FileStream fileStream = null;
            if (!File.Exists(Constanta.ConfigurationBorrow.filePath))
            {
                Console.WriteLine("Success Create File.");
                
            }
            else
            {
                Console.WriteLine("File Already exist");
                
            }
            viewBorrow.viewBorrow();
        }

        public void Addborrow()
        {
            Console.Clear();
            Console.WriteLine("Enter Data Borrow");
            Console.WriteLine("Borrow Id");
            borrowData.BorrowID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name ");
            borrowData.Name = Console.ReadLine();
            Console.WriteLine("Book Name ");
            borrowData.BookName = Console.ReadLine();
            Console.WriteLine("Address ");
            borrowData.Address = Console.ReadLine();
            Console.WriteLine("No Telpon ");
            borrowData.NoTelp = Console.ReadLine();
            borrowData.DateOfBorrow = DateTime.Now;
            Console.WriteLine("Date of Return ");
            borrowData.DateOfReturn = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Are you sure to save data? (Y/n)");
            string confirm = Console.ReadLine();
            if (confirm.ToUpper() == "Y")
            {
                writeToFile(borrowData);
            }
            //back home
            viewBorrow.viewBorrow();
        }

        public void readBorrow()
        {
            Console.Clear();
            if (File.Exists(Constanta.ConfigurationBorrow.filePath))
            {
                using (StreamReader streamReader = new StreamReader(Constanta.ConfigurationBorrow.filePath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            else
            {
                Console.WriteLine("File Doesn't exist");
            }
            //back home
            viewBorrow.viewBorrow();
        }

        public void readByIdBorrow()
        {
            Console.Clear();
            Console.WriteLine("Search by id");
            int id = Convert.ToInt32(Console.ReadLine());

            List<BorrowData> borrows = new List<BorrowData>();

            if (File.Exists(Constanta.ConfigurationBorrow.filePath))
            {
                string allText;
                FileStream fileStream = new FileStream(Constanta.ConfigurationBorrow.filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    allText = streamReader.ReadToEnd();
                }

                string[] rows = allText.Split(Constanta.ConfigurationBorrow.rowDelimeter);
                foreach(string row in rows)
                {
                    if(row.Length > 0 && !string.IsNullOrWhiteSpace(row.ToString()))
                    {
                        string[] columns = row.Split(Constanta.Configuration.columnDelimeter);
                        BorrowData borrowData = new BorrowData();
                        borrowData.BorrowID = Convert.ToInt32(columns[0]);
                        borrowData.Name = columns[1];
                        borrowData.BookName = columns[2];
                        borrowData.Address = columns[3];
                        borrowData.NoTelp = columns[4];
                        borrowData.DateOfBorrow = Convert.ToDateTime(columns[5]);
                        borrowData.DateOfReturn = Convert.ToDateTime(columns[6].Replace(";", ""));

                        borrows.Add(borrowData);
                    }
                }

                bool isFound = false;
                foreach(BorrowData borrow in borrows)
                {
                    if(id == borrow.BorrowID)
                    {
                        Console.WriteLine("Borrow Id : {0}", borrow.BorrowID);
                        Console.WriteLine("Name : {0}", borrow.Name);
                        Console.WriteLine("Book Name : {0}", borrow.BookName);
                        Console.WriteLine("Address : {0}", borrow.Address);
                        Console.WriteLine("No Telpon : {0}", borrow.NoTelp);
                        Console.WriteLine("Date of Borrow : {0}", borrow.DateOfBorrow);
                        Console.WriteLine("Date of Return : {0}", borrow.DateOfReturn);
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Borrow not Found");
                }
            }
            //Back Menu
            viewBorrow.viewBorrow();
        }

        public void updateById()
        {
            Console.Clear();
            Console.WriteLine("Enter id");
            int id = Convert.ToInt32(Console.ReadLine());

            List<BorrowData> borrows = new List<BorrowData>();

            if (File.Exists(Constanta.ConfigurationBorrow.filePath))
            {
                string allText;
                FileStream fileStream = new FileStream(Constanta.ConfigurationBorrow.filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    allText = streamReader.ReadToEnd();
                }

                string[] rows = allText.Split(Constanta.ConfigurationBorrow.rowDelimeter);
                foreach(string row in rows)
                {
                    if(row.Length > 8 && !string.IsNullOrWhiteSpace(row.ToString()))
                    {
                        string[] columns = row.Split(Constanta.ConfigurationBorrow.columnDelimeter);
                        BorrowData borrowData = new BorrowData();
                        borrowData.BorrowID = Convert.ToInt32(columns[0]);
                        borrowData.Name = columns[1];
                        borrowData.BookName = columns[2];
                        borrowData.Address = columns[3];
                        borrowData.NoTelp = columns[4];
                        borrowData.DateOfBorrow = Convert.ToDateTime(columns[5]);
                        borrowData.DateOfReturn = Convert.ToDateTime(columns[6].Replace(";", ""));

                        borrows.Add(borrowData);
                    }
                }

                bool isFound = false;
                foreach(BorrowData borrow in borrows)
                {
                    if(id == borrow.BorrowID)
                    {
                        Console.WriteLine("Borrow Id : {0}", borrow.BorrowID);
                        Console.WriteLine("Enter Id : ");
                        borrow.BorrowID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Name : {0}", borrow.Name);
                        Console.WriteLine("Enter Name : ");
                        borrow.Name = Console.ReadLine();

                        Console.WriteLine("Book Name : {0}", borrow.BookName);
                        Console.WriteLine("Enter Book Name : ");
                        borrow.BookName =Console.ReadLine();

                        Console.WriteLine("Address : {0}", borrow.Address);
                        Console.WriteLine("Enter Address : ");
                        borrow.Address = Console.ReadLine();

                        Console.WriteLine("No Telpon : {0}", borrow.NoTelp);
                        Console.WriteLine("Enter No Telpon : ");
                        borrow.NoTelp = Console.ReadLine();

                        borrow.DateOfBorrow = DateTime.Now;

                        Console.WriteLine("Date Of Return : {0}", borrow.DateOfReturn);
                        Console.WriteLine("Enter Date Of Return : ");
                        borrow.DateOfReturn = Convert.ToDateTime(Console.ReadLine());

                        isFound = true;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Borrow Not Found");
                }

                updateToFile(borrows);
            }

            //back to home
            viewBorrow.viewBorrow();
        }

        private void writeToFile(BorrowData borrowData)
        {
            if (File.Exists(Constanta.ConfigurationBorrow.filePath))
            {
                using (StreamWriter streamWriter = new StreamWriter(Constanta.ConfigurationBorrow.filePath, true))
                {
                    streamWriter.Write(streamWriter.NewLine);
                    streamWriter.Write("{0}| ", borrowData.BorrowID);
                    streamWriter.Write("{0}| ", borrowData.Name);
                    streamWriter.Write("{0}| ", borrowData.BookName);
                    streamWriter.Write("{0}| ", borrowData.Address);
                    streamWriter.Write("{0}| ", borrowData.NoTelp);
                    streamWriter.Write("{0}| ", borrowData.DateOfBorrow);
                    streamWriter.Write("{0};", borrowData.DateOfReturn);
                }
            }
            else
            {
                Console.WriteLine("File Doesn't Exist");
            }
        }

        private void updateToFile(List<BorrowData> borrows)
        {
            if (File.Exists(Constanta.ConfigurationBorrow.filePath))
            {
                using (StreamWriter streamWriter = new StreamWriter(Constanta.ConfigurationBorrow.filePath))
                {
                    foreach(BorrowData borrow in borrows)
                    {
                        streamWriter.Write("{0}| ", borrow.BorrowID);
                        streamWriter.Write("{0}| ", borrow.Name);
                        streamWriter.Write("{0}| ", borrow.BookName);
                        streamWriter.Write("{0}| ", borrow.Address);
                        streamWriter.Write("{0}| ", borrow.NoTelp);
                        streamWriter.Write("{0}| ", borrow.DateOfBorrow);
                        streamWriter.Write("{0};", borrow.DateOfReturn);
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
        }
    }
}
