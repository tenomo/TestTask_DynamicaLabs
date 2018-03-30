using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HubSportService.DTO;
using HubSportService.Helpers;
using Newtonsoft.Json;

namespace HubSportService.Services
{
    public class CompanyService :   ICompanyService
    {
        private HttpClient httpClient;
    

        public CompanyService(HttpClient httpClient )
        {
            this.httpClient = httpClient; 
        }
        public async Task<Company> GetCompany(long companyId)
        {
            try
            {
              

                StringBuilder builder = new StringBuilder();
                builder.Append("https://api.hubapi.com/companies/v2/companies/");
                builder.Append(companyId);
                builder.Append("?hapikey=demo");
                var url = builder.ToString();

                var companiesResponseJson = await httpClient.GetStringAsync(url);
                var companiesResponse =
                    await Task.Run(() => JsonConvert.DeserializeObject<dynamic>(companiesResponseJson));

                var company = new Company
                {
                    Name = JsonPropertyParser.GetPropertyValue(companiesResponse.properties, "name"),
                    CompanyId = companyId,
                    City = JsonPropertyParser.GetPropertyValue(companiesResponse.properties, "city"),
                    Phone = JsonPropertyParser.GetPropertyValue(companiesResponse.properties, "phone"),
                    State = JsonPropertyParser.GetPropertyValue(companiesResponse.properties, "state"),
                    Website = JsonPropertyParser.GetPropertyValue(companiesResponse.properties, "website"),
                    Zip = JsonPropertyParser.GetPropertyValue(companiesResponse.properties, "zip"),

                };

                return company;
            }
            catch (Exception ex)
            {
                Trace.TraceError( "failed get company by id: " + companyId,ex);
                

                return null;
            }
        }
         
    }
}

