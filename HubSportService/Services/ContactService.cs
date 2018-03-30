using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using HubSportService.DTO;
using HubSportService.Helpers;
using Newtonsoft.Json;

namespace HubSportService.Services
{
    public class ContactService : IContactService
    {
        private   HttpClient httpClient; 

        public ContactService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Contact>> GetUpdatedContacts(DateTime modifiedOnOrAfter)
        { 
            var utcModifiedOnOrAfter = ((DateTimeOffset) modifiedOnOrAfter).ToUnixTimeSeconds();
  
            //todo user id offset.
            var url = 
                "https://api.hubapi.com/contacts/v1/lists/recently_updated/contacts/recent?hapikey=demo&count=1000&property=lastname&property=lifecyclestage&property=firstname&property=company&property=associatedcompanyid&" +
                $"time-offset={utcModifiedOnOrAfter}";
             
            Trace.WriteLine("Request to hub sport");
            Trace.WriteLine("url " + url);
            var contactsResponseJson = await httpClient.GetStringAsync(url);
            var contactsResponse   = JsonConvert.DeserializeObject<dynamic>(contactsResponseJson);
            var contacts = new List<Contact>();
            long contactsCount = contactsResponse.contacts.Count;
            Trace.WriteLine("Results count " + contactsCount);
            for (var i = 0; i < contactsCount; i++)
            {
                var contact = contactsResponse.contacts[i];
                contacts.Add(InternacContactFactory.Create(contact));}
            return contacts;
        }

  

        private static class InternacContactFactory 
        {
            public static Contact Create(dynamic jsonObject)
            {
                long companyId;
                long.TryParse(JsonPropertyParser.GetPropertyValue(jsonObject.properties, "associatedcompanyid"), out companyId);
                var newContact = new Contact
                {
                    Id = jsonObject["canonical-vid"],//.vid,
                    FirstName = JsonPropertyParser.GetPropertyValue(jsonObject.properties, "firstname"),
                    LastName = JsonPropertyParser.GetPropertyValue(jsonObject.properties, "lastname"),
                    LifecycleStage = JsonPropertyParser.GetPropertyValue(jsonObject.properties, "lifecyclestage"),
                    CompanyId = companyId
                };
                return newContact;
            }
        }
    }
}

    

   

 

