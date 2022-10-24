using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils
{
    public class ExcelUtil
    {

        IReportDal _reportDal = new EfReportDal();

        public static string CreateExcelFile(Dictionary<string,int> peopleCount , Dictionary<string, int> gsmCount, string location)
        {
            string directory = Directory.GetCurrentDirectory().Substring(0, (Directory.GetCurrentDirectory().Length) - 17);
            string foldername = "\\reports\\";
            var file = new FileInfo(directory+foldername+"report_" + (string.IsNullOrEmpty(location) ? "global":location) + ".xlsx");


            return SaveExcelFile(file, peopleCount, gsmCount, location);
        }

        private static string SaveExcelFile(FileInfo file , Dictionary<string, int> peopleCount, Dictionary<string, int> gsmCount, string location) {
            CheckExists(file);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("Report");

            ws.Cells[1, 1].Value = "Konum";
            ws.Cells[1, 2].Value = "Kişi Sayısı";
            ws.Cells[1, 3].Value = "Telefon Numarası Sayısı";

            ws.Cells[1, 1].AutoFitColumns();
            ws.Cells[1, 2].AutoFitColumns();
            ws.Cells[1, 3].AutoFitColumns();


            if (string.IsNullOrEmpty(location))
            {
                int row = 2;
                int column = 1;
                foreach (var item in peopleCount) {
                    ws.Cells[row, column].Value = item.Key;
                    column++;
                    ws.Cells[row, column].Value = item.Value;
                    row++;
                    column--;
                }

                column = 3;
                row = 2;
                foreach (var item in gsmCount)
                {
                    ws.Cells[row, column].Value = item.Value;
                    row++;
                }



            }
            else {
                ws.Cells[2, 1].Value = location;
                ws.Cells[2, 2].Value = peopleCount.GetValueOrDefault(location);
                ws.Cells[2, 3].Value = gsmCount.GetValueOrDefault(location);
            }
            package.Save();

            return file.Directory.FullName;

        }

        private static void CheckExists(FileInfo file) {

            if (file.Exists) {
                file.Delete();
            }

        }

        public void uploadReportEntity(string path)
        {
            Report report = _reportDal.Get(item => item.IsCompleted == false);

            report.IsCompleted = true;
            report.FilePath = path;
            report.CompletedDate = DateTime.Now;

            _reportDal.Update(report);
        }

    }
}
