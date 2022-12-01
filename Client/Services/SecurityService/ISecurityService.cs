using Fintech.Shared.Models;

namespace Fintech.Client.Services.SecurityService
{
    public interface ISecurityService
    {
        Task<List<Security>> GetSecurities();
        Task<Security?> GetSecurityById(int id);
        Task CreateSecurity(Security security);
        Task EditSecurity(Security security);
        Task DeleteSecurity(int securityId);
        string Message { get; set; } //to display if no security was to be found
    }
}
