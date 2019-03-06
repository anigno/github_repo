using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AnignoraCommonAndHelpers.Helpers;
using AnignoraCommonAndHelpers;

namespace ExcelColumnSplitter
{
    class Program
    {
        static void Main()
        {
            //int columnNumber;
            //Console.WriteLine("xls file:");
            //string filename = Console.ReadLine();
            //if (!File.Exists(filename))
            //{
            //    Console.WriteLine("File not found!");
            //    Console.ReadKey();
            //    return;
            //}
            //Console.WriteLine("Column Number:");
            //string sColumn = Console.ReadLine();
            //bool bResult = int.TryParse(sColumn, out columnNumber);
            //if (!bResult)
            //{
            //    Console.WriteLine("Column number illegal!");
            //    Console.ReadKey();
            //    return;
            //}
            //Console.WriteLine("Sheet Name:");
            //string sheetName = Console.ReadLine();

            string filename = @"c:\temp\1.xls";
            string sheetName = "Sheet 1";
            int length = 4100;
            int columnNumber = 0;
            string[][] excelFile = OfficeAutomationHelper.ReadExcelFile(filename, sheetName, "A1", "A"+length);
            string[] splitter={" "};
            List<string[]> listRet=new List<string[]>();
            foreach (string[] sLine in excelFile)
            {
                string[] sa = sLine[columnNumber].Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                for (int a = 0; a < sa.Length; a++)
                {
                    File.AppendAllText(@"c:\temp\Column" + a, sa[a] );
                }
                for (int a = 0; a < 10; a++)
                {
                    File.AppendAllText(@"c:\temp\Column" + a, Environment.NewLine);
                }
                

                //if (sa.Length == 0)
                //{
                //    string[] sName = { "-", "-" };
                //    listRet.Add(sName);
                //}
                if (sa.Length == 1)
                {
                    string[] sName = { sa[0], "-" };
                    listRet.Add(sName);
                }
                if (sa.Length == 2)
                {
                    string[] sName = {sa[0], sa[1]};
                    listRet.Add(sName);
                }
                if (sa.Length == 3)
                {
                    string[] sName = { sa[0] + " " + sa[1], sa[2] };
                    listRet.Add(sName);
                }
                if (sa.Length >= 4)
                {
                    string[] sName = { sa[0] + " " + sa[1] + " " + sa[2], sa[3] };
                    listRet.Add(sName);
                }
            }

            TextWriter tw = new StreamWriter(@"c:\temp\Names.csv");
            TextWriter tw1 = new StreamWriter(@"c:\temp\Names1.csv");
            foreach (string[] sa in listRet)
            {
                tw.WriteLine(sa[0]);
                tw1.WriteLine(sa[1]);
            }
            tw.Close();
            tw1.Close();

            Console.WriteLine("Finished");
            //Console.ReadKey();

        }
    }
}
