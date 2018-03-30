using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HubSportService.DTO;

namespace HubSportService.Services
{
    public interface IContactService
    { 

        Task<IEnumerable<Contact>> GetUpdatedContacts(DateTime modifiedOnOrAfter );
    }
}