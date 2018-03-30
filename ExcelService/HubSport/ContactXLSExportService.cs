using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using HubSportService.DTO;
using Microsoft.Office.Interop.Excel;

namespace ExcelService.HubSport
{
    public class ContactXlsExportService : IContactXlsExportService
    {
     
        private   Application xlApp;
        private readonly Workbook xlWorkBook;
        private readonly Worksheet xlWorkSheet;

        private const int RowFactor = 2;

        private object MissingValue => System.Reflection.Missing.Value;

        public ContactXlsExportService()
        {
             xlApp = new Application();
            xlWorkBook = xlApp.Workbooks.Add(MissingValue);
            xlWorkSheet = ( Worksheet)xlWorkBook.Worksheets.get_Item(1);

        }

        private int GetRowNumber(int elementIndex) => elementIndex + RowFactor;

        public void Export(IEnumerable<Contact> list, string pathToSave)
        {
            Trace.WriteLine($"Start export to {pathToSave}");
            
            xlWorkSheet.Cells[1, 1] = "Contact Id";
            xlWorkSheet.Cells[1, 2] = "Contact first name";
            xlWorkSheet.Cells[1, 3] = "Contact last name";
            xlWorkSheet.Cells[1, 4] = "Contact lifecycle stage";
            xlWorkSheet.Cells[1, 5] = "Company id";
            xlWorkSheet.Cells[1, 6] = "Company name";
            xlWorkSheet.Cells[1, 7] = "Company website ";
            xlWorkSheet.Cells[1, 8] = "Company city";
            xlWorkSheet.Cells[1, 9] = "Company state";
            xlWorkSheet.Cells[1, 10] = "Company zip";
            xlWorkSheet.Cells[1, 11] = "Company phone";
            var contactsArra = list.ToArray();
            for (int i = 0; i < list.Count(); i++)
            {
                var contact = contactsArra[i];

                var row = GetRowNumber(i);
                xlWorkSheet.Cells[row, 1] = contact.Id;
                xlWorkSheet.Cells[row, 2] = contact.FirstName;
                xlWorkSheet.Cells[row, 3] = contact.LastName;
                xlWorkSheet.Cells[row, 4] = contact.LifecycleStage;

                if (contact.Company != null) { 
                xlWorkSheet.Cells[row, 5] = contact?.Company.CompanyId;
                xlWorkSheet.Cells[row, 6] = contact?.Company.Name;
                xlWorkSheet.Cells[row, 7] = contact?.Company.Website;
                xlWorkSheet.Cells[row, 8] = contact?.Company.City;
                xlWorkSheet.Cells[row, 9] = contact?.Company.State;
                xlWorkSheet.Cells[row, 10] = contact?.Company.Zip;
                xlWorkSheet.Cells[row, 11] = contact?.Company.Phone;
                }

            }

           
                xlWorkBook.SaveAs(pathToSave, XlFileFormat.xlWorkbookNormal, MissingValue, MissingValue, MissingValue,
                             MissingValue, XlSaveAsAccessMode.xlExclusive, MissingValue, MissingValue, MissingValue, MissingValue,
                             MissingValue);

              

             xlWorkBook.Close(false, pathToSave, MissingValue);
            xlApp.Quit();


            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            Trace.WriteLine($"Exposrt success");

            OpenFile(pathToSave);
        }

        public void OpenFile(string path)
        {
            Trace.WriteLine($"Open file {path}");
            xlApp = new Application();
            Workbook wb = xlApp.Workbooks.Open(path);
            xlApp.Visible = true;
        }
    }
}
