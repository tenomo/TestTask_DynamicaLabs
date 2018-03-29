using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DynamicaLabsTT
{
  public  class CompanyService
    {
        public  async Task<string> GetUpdatedContacts( )
        {
            var httpClient = new HttpClient();
  
        
          var contactsResponseJson = await httpClient.GetStringAsync("https://api.hubapi.com/contacts/v1/lists/all/contacts/all?hapikey=demo&count=10&property=lastname&property=lifecyclestage&property=firstname&property=company&property=associatedcompanyid");

           
              var contactsResponse = await Task.Run(() =>  JsonConvert.DeserializeObject<dynamic>(contactsResponseJson));
        
    
         List< Contact > contacts = new List<Contact>();


            var contactsCount = contactsResponse.contacts.Count;

           
           
            for (var i = 0; i < contactsCount; i++)
            {

                var contact = contactsResponse.contacts[i];
                Console.WriteLine(contact.vid);
                Console.WriteLine(contact.properties.firstname.value);
                Console.WriteLine(contact.properties.lastname.value);
                Console.WriteLine(contact.properties.lifecyclestage.value);
                Console.WriteLine(contact.properties.associatedcompanyid.value);


                StringBuilder builder = new StringBuilder();
                builder.Append("https://api.hubapi.com/companies/v2/companies/");
                builder.Append(contact.properties.associatedcompanyid.value);
                builder.Append("?hapikey=demo");
                 builder.Append("&property=name");
                 builder.Append("&property=website");
                 builder.Append("&property=city");
                 builder.Append("&property=state");
                 builder.Append("&property=zip");
                 builder.Append("&property=phone");
                // var companiesResponseJson = await httpClient.GetStringAsync($"https://api.hubapi.com/companies/v2/companies/{contact.properties.associatedcompanyid.value)}?hapikey=demo");

           //     Console.WriteLine(builder.ToString());
                var companiesResponseJson = await httpClient.GetStringAsync(builder.ToString());
                var companiesResponse = await Task.Run(() => JsonConvert.DeserializeObject<dynamic>(companiesResponseJson));
                Console.WriteLine("associated_company");
                // Console.WriteLine(companiesResponse.properties);

                try
                {
                    Console.WriteLine(companiesResponse.properties.name.value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("name " + ex.Message);
                }
                try
                {
                    Console.WriteLine(companiesResponse.properties.website.value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("value " + ex.Message);
                }
                try
                {
                    Console.WriteLine(companiesResponse.properties.city.value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("city " + ex.Message);
                }
                try
                {
                    Console.WriteLine(companiesResponse.properties.state.value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("state " + ex.Message);
                }
                try
                {
                    Console.WriteLine(companiesResponse.properties.zip.value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("zip " + ex.Message);
                }
                try
                {
                    Console.WriteLine(companiesResponse.properties.phone.value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("phone " + ex.Message);
                }
//                Console.WriteLine(companiesResponse.properties.name.value);
//                Console.WriteLine(companiesResponse.properties.website.value);
//                Console.WriteLine(companiesResponse.properties.city.value);
//                Console.WriteLine(companiesResponse.properties.state.value);
//                Console.WriteLine(companiesResponse.properties.zip.value);
//                Console.WriteLine(companiesResponse.properties.phone.value);
             
 

                Console.WriteLine("");
            }

  

            return contactsResponseJson;
        }

        private Contact Parce(dynamic contact)
        {
            return new Contact
            {

            };
        }
    }

    

    public class Contact
    {
        public UInt64 vid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Company Company { get; set; }

        public override string ToString()
        {
            return $"{nameof(vid)}: {vid}, {nameof(firstname)}: {firstname}, {nameof(lastname)}: {lastname}, {nameof(Company)}: {Company}";
        }
    }

    public class Company
    {
        public UInt64 companyId { get; set; }
        public string name { get; set; }
        public string website { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
    }

}

