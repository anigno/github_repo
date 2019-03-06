using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel; 

namespace WorkingWithExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            //BlackSholesTested blackSholesTested=new BlackSholesTested();
            //double vcall=blackSholesTested.BlackScholes(BlackSholesTested.CallPutEnum.Call, 157.06, 158, 11/365d,0.01,0.201);
            //double vput=blackSholesTested.BlackScholes(BlackSholesTested.CallPutEnum.Put, 10, 12, 3/365d, 11, 5);


            //Console.ReadKey();
            //return;
            string workbookPath = "Book1.xlsx";
            var absolutePath = Path.GetFullPath(workbookPath);

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(absolutePath,
                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);
            Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "Sheet1";
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
            excelWorksheet.Cells[1, 1] = 4.1;
            excelWorksheet.Cells[2, 1] = 3.2;
            Excel.Range excelCell =(Excel.Range)excelWorksheet.get_Range("B1", "B1");
            dynamic v2 = excelCell.Value2;

            Excel.Range excelRange = (Excel.Range)excelWorksheet.get_Range("A1", "A2");
            excelRange.Value2 = new float[,] { { 1.12f }, { 5f } };

            excelCell = (Excel.Range)excelWorksheet.get_Range("B1", "B1");
            v2 = excelCell.Value2;

            object missing = Type.Missing;

            excelWorkbook.Save();

            excelWorkbook.Close(missing,missing,missing);
            excelApp.UserControl = true;
            excelApp.Quit();

            if (excelCell != null)
            {
                Marshal.FinalReleaseComObject(excelCell);
                excelCell = null;
            }
            if (excelWorksheet != null)
            {
                Marshal.FinalReleaseComObject(excelWorksheet);
                excelWorksheet = null;
            }
            if (excelWorkbook != null)
            {
                Marshal.FinalReleaseComObject(excelWorkbook);
                excelWorkbook = null;
            }
            if (excelApp != null)
            {
                Marshal.FinalReleaseComObject(excelApp);
                excelApp = null;
            }
        }
    }
}
