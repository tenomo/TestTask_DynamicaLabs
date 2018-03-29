using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicaLabsTT
{
    class Program
    {
        static void Main(string[] args)
        {
            HubSpotClient client = new HubSpotClient();
           var x = client.GetUpdatedContacts().Result;
        }
    }
}
