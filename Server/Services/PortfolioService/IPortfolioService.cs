using Fintech.Shared.Models;

namespace Fintech.Server.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<ServiceResponse<List<Portfolio>>> GetPortfoliosAsync();
        Task<ServiceResponse<Portfolio>> GetPortfolioByIdAsync(int id);
        Task<ServiceResponse<Portfolio>> GetPortfolioByNameAsync(string name);
        Task<ServiceResponse<int>> CreatePortfolioAsync(Portfolio portofolio);
        Task<ServiceResponse<int>> EditPortfolioAsync(Portfolio portofolio);
        Task<ServiceResponse<int>> DeletePortfolioAsync(int portfolioId);
        Task<ServiceResponse<string>> GetPortfolioNameBySecurityAsync(Security security);

    }
}
