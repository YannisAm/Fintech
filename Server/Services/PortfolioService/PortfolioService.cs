using Fintech.Shared.Models;

namespace Fintech.Server.Services.PortfolioService
{
    public class PortfolioService : IPortfolioService
    {
        private DataContext _context;

        public PortfolioService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> CreatePortfolioAsync(Portfolio portofolio)
        {
            _context.Portofolios.Add(portofolio);
            var result = await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = result,
                Success = result > 0,
                Message = "The" + portofolio.NameOfPortfolio + "has been saved!"
            };
        }

        public async Task<ServiceResponse<int>> DeletePortfolioAsync(int portfolioId)
        {
            var foundPortfolio = await _context.Portofolios
                .FirstOrDefaultAsync(p => p.Id == portfolioId);
            _context.Portofolios.Remove(foundPortfolio);
            var result = await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = result,
                Message = "Your security has been deleted"
            };
        }

        public async Task<ServiceResponse<int>> EditPortfolioAsync(Portfolio portofolio)
        {
            _context.Portofolios.Update(portofolio);
            var result = await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = result,
                Success = result > 0,
                Message = "The" + portofolio.NameOfPortfolio + "has been edited."
            };
        }

        public async Task<ServiceResponse<Portfolio>> GetPortfolioByIdAsync(int id)
        {
            var portfolio = await _context.Portofolios
                .FirstOrDefaultAsync(p => p.Id == id);

            return new ServiceResponse<Portfolio>
            {
                Data = portfolio
            };
        }

        public async Task<ServiceResponse<List<Portfolio>>> GetPortfoliosAsync()
        {
            return new ServiceResponse<List<Portfolio>>
            {
                Data = await _context.Portofolios.ToListAsync()
            };
        }

    }
}
