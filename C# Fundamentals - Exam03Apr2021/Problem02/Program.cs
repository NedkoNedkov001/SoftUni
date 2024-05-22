using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());

            string pattern = @"(?<start>.+)>(?<numbers>\d+)\|(?<lower>\w+)\|(?<upper>\w+)\|(?<symbols>[^<>]+)<(\1)";
            Regex regex = new Regex(pattern);

            string password = "##>123|yes|YES|!!!<##";

            Match match = regex.Match(password);
        }
    }
}
