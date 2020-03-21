using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;

namespace CommsecPOM.Data
{
    public class ExcelDataOperation
    {

        public static void readExcelData()
        {
            excel.Application x1app = new excel.Application();

            excel.Workbook x1workbook = x1app.Workbooks.Open(@"C:\Users\Thomas\source\repos\CommsecPOM\CommsecPOM\Data\OrangeData.xlsx");

            excel.Worksheet x1worksheet = x1workbook.Sheets[1];

            excel.Range x1range = x1worksheet.UsedRange;

            string fullName;

            for (int i = 2; i <= 2; i++)
            {
                fullName = x1range.Cells[i][1].value2;
                Console.WriteLine(fullName);
            }

        }
       



    }
}
