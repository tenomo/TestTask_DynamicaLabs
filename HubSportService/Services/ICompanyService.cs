using System.Threading.Tasks;
using HubSportService.DTO;

namespace HubSportService.Services
{
    public interface ICompanyService
    { 
        Task<Company> GetCompany(long companyId);
    }
}