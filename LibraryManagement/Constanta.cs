using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Constanta
    {
        public class Configuration
        {
            public const string filePath = "Buku.txt";
            public const char rowDelimeter = ';';
            public const char columnDelimeter = '|';
        }

        public class ConfigurationBorrow
        {
            public const string filePath = "Peminjam.txt";
            public const char rowDelimeter = ';';
            public const char columnDelimeter = '|';
        }
    }
}
