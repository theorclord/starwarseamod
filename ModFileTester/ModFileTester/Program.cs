using System;
using System.Collections.Generic;
using System.IO;

namespace ModFileTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            string myFilePath = @"C:\projects\starwarseamod\My_Mod\Data\XML\CAMPAIGNS_UNDERWORLD_GC.XML";
            string compareFilePath = @"C:\projects\starwarseamod\CompareFiles\CAMPAIGNS_UNDERWORLD_GC.XML";

            string myFileContent = "";
            using(TextReader reader = new StreamReader(myFilePath))
            {
                myFileContent = reader.ReadToEnd();
            }

            string compareContent = "";
            using (TextReader reader = new StreamReader(compareFilePath))
            {
                compareContent = reader.ReadToEnd();
            }

            string[] myFileLines = myFileContent.Split("\r\n");
            string[] compareFileLines = compareContent.Split("\r\n");


            Dictionary<int, string> lineDifference = new Dictionary<int, string>();
            for(int i = 0; i< myFileLines.Length; i++)
            {

                if(myFileLines[i] != compareFileLines[i])
                {
                    lineDifference.Add(i, compareFileLines[i]);
                }

            }

            foreach(KeyValuePair<int,string> lineDiff in lineDifference)
            {
                Console.WriteLine($"{lineDiff.Key}: {lineDiff.Value}");
            }

        }
    }
}
