using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;

namespace AnignoLibrary.Helpers
{
    [TestFixture]
    public class OfficeAutomationHelper
    {
        public static string[][] ReadExcelFile(string workbookPath, string currentSheet,string rangeStart,string rangeEnd)
        {
            List<string[]> lRet = new List<string[]>();
            Application excelApp = new ApplicationClass();
            excelApp.Visible = true;
            Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Sheets excelSheets = excelWorkbook.Worksheets;
            Worksheet excelWorksheet = (Worksheet) excelSheets.get_Item(currentSheet);
            Range excelRange = excelWorksheet.get_Range(rangeStart, rangeEnd);
            int totalColumns = excelRange.Columns.Count;
            int totalRows = excelRange.Rows.Count;
            for (int r = 1; r <= totalRows; r++)
            {
                string[] sa = new string[totalColumns];
                for (int c = 1; c <= totalColumns; c++)
                {
                    object o = ((Range) excelRange.get_Item(r, c)).Value2;
                    string v = o == null ? "" : o.ToString();
                    sa[c-1] = v;
                }
                lRet.Add(sa);
            }
            excelApp.Workbooks.Close();
            return lRet.ToArray();
        }

        [Test]
        public void Test_ReadExcelFile()
        {
            string[][] saa=ReadExcelFile(@"E:\_Temp\1\goog.xls", "goog", "A1", "D8");
        }
    }
}
