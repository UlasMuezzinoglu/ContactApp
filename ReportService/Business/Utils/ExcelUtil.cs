using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils
{
    public static class ExcelUtil
    {
        public static void CreateExcelFile(int peopleCount , int gsmCount, string location)
        {
            string directory = Directory.GetCurrentDirectory().Substring(0, (Directory.GetCurrentDirectory().Length) - 17);
            string foldername = "\\reports\\";
            var file = new FileInfo(directory+foldername+"report_"+location + ".xlsx");


            SaveExcelFile(file, peopleCount, gsmCount, location);
        }

        private static void SaveExcelFile(FileInfo file , int peopleCount, int gsmCount, string location) {
            CheckExists(file);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add(location);

            ws.Cells[1, 1].Value = "Belirttiğiniz Konumda ki Kişi Sayısı";
            ws.Cells[1, 2].Value = "Belirttiğiniz Konumda ki Gsm Sayısı";

            ws.Cells[1, 1].AutoFitColumns();
            ws.Cells[1, 2].AutoFitColumns();

            ws.Cells[2, 1].Value = peopleCount;
            ws.Cells[2, 2].Value = gsmCount;

            package.Save();
          
        }

        private static void CheckExists(FileInfo file) {

            if (file.Exists) {
                file.Delete();
            }

        }
        
    }
}
