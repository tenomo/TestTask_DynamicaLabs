using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicaLabsTT.UI.Infrastructure;
using ExcelService.HubSport;
using HubSportService.Services;
using System.Collections.Generic;
using HubSportService.DTO;

namespace DynamicaLabsTT.UI
{
    public partial class ContactsExposrterForm : Form
    {
        public ContactsExposrterForm()
        {
            InitializeComponent();
            Trace.Listeners.Add(new TextBoxTraceListener(textBox1));
        }
        public IContactService ContactService { get; set; }
        public ICompanyService CompanyService { get; set; }
        public IContactXlsExportService ContactXlsExportService { get; set; }

        
        private async void button1_Click(object sender, EventArgs e)
        {
            string selectedDirectory = string.Empty;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    selectedDirectory = fbd.SelectedPath;

                else
                {
                    MessageBox.Show(@"You must select directory");
                    return;
                }

            }


            var contacts = await ContactService.GetUpdatedContacts(dateTimePicker1.Value.Date);
            Trace.WriteLine("contacts count " + contacts.Count());
            foreach (var contact in contacts)
            {
                
               if (contact.CompanyId > 0)
                    contact.Company = await CompanyService.GetCompany(contact.CompanyId);

            }
            var pathToSave =
                $"{selectedDirectory}contacts-{dateTimePicker1.Value.ToString().Replace(":", "-")}.xls";
            ContactXlsExportService.Export(contacts, pathToSave);

        }
    }
}
