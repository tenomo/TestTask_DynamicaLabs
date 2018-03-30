using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExcelService.HubSport;
using HubSportService.Services;
using Excel = Microsoft.Office.Interop.Excel;
 
namespace DynamicaLabsTT
{
    class Program
    {
        static async Task f()
        {
            Console.WriteLine("-1");
             await Task.Factory.StartNew(() =>
            {
                Console.WriteLine("0");
                Thread.Sleep(3000);
                Console.WriteLine("1");
            });
            Console.WriteLine("2");
        }
     
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting Main");
            Trace.Unindent();


            //           var httpClient  = new HttpClient();
            //  ICompanyService    companyService= new CompanyService(httpClient);
            //           IContactService   contactService= new ContactService(httpClient, companyService);

            //           IContactXlsExportService  contactXlsExportService = new ContactXlsExportService($"d:\\{Guid.NewGuid().ToString()}.xls");

            //           Random random = new Random();

            //          // for (int y = 2015; y < 2018; y++)
            //         //  {


            //                   ///   Thread.Sleep(random.Next(900, 1500));
            //                   for (int m = 1; m <= 4; m++)
            //                   {
            //               int failCount = 0;
            //               int succesCount = 0;  //Thread.Sleep(random.Next(200, 300));
            //               for (int d = 1; d <= 28; d++)
            //                       {
            //                           //   Thread.Sleep(random.Next(5, 20));
            //                           try
            //                           {
            //                               DateTime dateTime = new DateTime(18, m, d);
            //                               var x1 = contactService.GetUpdatedContacts(dateTime).Result ;

            //Console.WriteLine($"x1:{x1.FirstOrDefault().Id}; x2:{ x1.LastOrDefault().Id}; ");

            //                               //    Console.WriteLine(contactService.GetUpdatedContacts(dateTime).Result.Count());
            //                       succesCount++;
            //                           }
            //                           catch
            //                           {
            //                               failCount++;
            //                           }
            //                           //   dateTime = dateTime.AddDays(1);
            //                       }
            //               //   dateTime = dateTime.AddMonths(1);

            //               Console.WriteLine("failCount:" + failCount);
            //               Console.WriteLine("succesCount:" + succesCount + Environment.NewLine);
            //           }
            //    Console.WriteLine("Year:" + y);



            //   }

            //  contactService.GetUpdatedContacts().Result;


            //  contactXlsExportService.Export(contactService.GetUpdatedContacts( ).Result);





            //Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();




            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;

            //xlWorkBook = xlApp.Workbooks.Add(misValue);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            //xlWorkSheet.Cells[1, 1] = "Contact Id";
            //xlWorkSheet.Cells[1, 2] = "Contact first name";
            //xlWorkSheet.Cells[1, 3] = "Contact last name";
            //xlWorkSheet.Cells[1, 4] = "Contact lifecycle stage";
            //xlWorkSheet.Cells[1, 5] = "Company id";
            //xlWorkSheet.Cells[1, 6] = "Company name";
            //xlWorkSheet.Cells[1, 7] = "Company website ";
            //xlWorkSheet.Cells[1, 8] = "Company city";
            //xlWorkSheet.Cells[1, 9] = "Company state";
            //xlWorkSheet.Cells[1, 10] = "Company zip";
            //xlWorkSheet.Cells[1, 11] = "Company phone";


            //var list =  contactService.GetUpdatedContacts().Result.ToArray();

            //for (int i = 2; i < list.Count(); i++)
            //{
            //    var contact = list[i];
            //    //try
            //    //{
            //    //    list[i].Company = companyService.GetCompany(contact.CompanyId).Result;
            //    //    Console.WriteLine(list[i].Company);
            //    //}
            //    //catch
            //    //{
            //    //}
            //    xlWorkSheet.Cells[i, 1] = contact.Id;
            //    xlWorkSheet.Cells[i, 2] = contact.FirstName;
            //    xlWorkSheet.Cells[i, 3] = contact.LastName;
            //    xlWorkSheet.Cells[i, 4] = contact.LifecycleStage;

            //    try
            //    {
            //        xlWorkSheet.Cells[i, 5] = contact?.Company.CompanyId;
            //        xlWorkSheet.Cells[i, 6] = contact?.Company.Name;
            //        xlWorkSheet.Cells[i, 7] = contact?.Company.Website;
            //        xlWorkSheet.Cells[i, 8] = contact?.Company.City;
            //        xlWorkSheet.Cells[i, 9] = contact?.Company.State;
            //        xlWorkSheet.Cells[i, 10] = contact?.Company.Zip;
            //        xlWorkSheet.Cells[i, 11] = contact?.Company.Phone;
            //    }
            //    catch
            //    {
            //    }
            //}





            //var path = $"d:\\{Guid.NewGuid().ToString()}.xls";
            //xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


            //// xlWorkBook.Close(false, path, misValue);
            ////   xlApp.Quit();
            //xlApp.Visible = true;
            //Marshal.ReleaseComObject(xlWorkSheet);
            //Marshal.ReleaseComObject(xlWorkBook);
            //Marshal.ReleaseComObject(xlApp);




        }
    }
}
