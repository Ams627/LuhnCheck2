using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace LuhnCheck
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                foreach (var arg in args)
                {
                    if (IsLuhnOK(arg))
                    {
                        Console.WriteLine($"{arg} OK");
                    }
                    else
                    {
                        Console.WriteLine($"{arg} BAD!!!!!!!!!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }

        private static bool IsLuhnOK(string s)
        {
            int l = s.Length;
            if (l < 2) return false;

            bool doubleIt = false;
            var sum = 0;
            for (int i = l - 1; i >= 0; i--, doubleIt = !doubleIt)
            {
                if (!char.IsDigit(s[i])) return false;
                var d = s[i] - '0';
                sum += doubleIt ? ((d *= 2) > 9 ? d - 9 : d) : d;
            }

            return sum % 10 == 0;
        }
    }
}
