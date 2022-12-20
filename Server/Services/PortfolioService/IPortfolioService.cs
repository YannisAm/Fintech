using Fintech.Shared.Models;

namespace Fintech.Server.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<ServiceResponse<List<Portfolio>>> GetPortfoliosAsync(string email);
        Task<ServiceResponse<Portfolio>> GetPortfolioByIdAsync(int id);
        Task<ServiceResponse<int>> CreatePortfolioAsync(Portfolio portofolio);
        Task<ServiceResponse<int>> EditPortfolioAsync(Portfolio portofolio);
        Task<ServiceResponse<int>> DeletePortfolioAsync(int portfolioId);
    }
}
