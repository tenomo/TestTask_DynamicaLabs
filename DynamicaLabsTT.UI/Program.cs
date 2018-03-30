using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ExcelService.HubSport;
using HubSportService.Services;

namespace DynamicaLabsTT.UI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(Component.For<HttpClient>()
               .ImplementedBy<HttpClient>());

            container.Register(Component.For<IContactService>()
                .ImplementedBy<ContactService>().DependsOn(container.Resolve<HttpClient>()));

            container.Register(Component.For<ICompanyService>()
                .ImplementedBy<CompanyService>().DependsOn(container.Resolve<HttpClient>()));

            container.Register(Component.For<IContactXlsExportService>()
             .ImplementedBy<ContactXlsExportService>());

            container.Register(Component.For<ContactsExposrterForm>()
                .ImplementedBy<ContactsExposrterForm>() );

         


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<ContactsExposrterForm>());

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ContactsExposrterForm());
        }
    }
}
