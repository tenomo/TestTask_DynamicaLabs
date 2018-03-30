using System.Collections.Generic;
using HubSportService.DTO;

namespace ExcelService.HubSport
{
    public interface IContactXlsExportService
    {
        void Export(IEnumerable<Contact> list,   string pathToSave);
        void OpenFile(string path);
    }
}