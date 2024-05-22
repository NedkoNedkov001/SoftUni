using System;
using System.IO.Compression;

namespace ZipFileAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:/Pictures/CSGO PFPs", @"D:/Pictures/Archive.zip");
            ZipFile.ExtractToDirectory(@"D:/Pictures/Archive.zip", @"D:/Pictures/CSGO PFPs-Copy");
        }
    }
}
