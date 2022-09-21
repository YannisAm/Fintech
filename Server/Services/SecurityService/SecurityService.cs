using Fintech.Shared.Models;

namespace Fintech.Server.Services.SecurityService
{
    public class SecurityService : ISecurityService
    {
        private DataContext _context;

        public SecurityService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Security>>> GetSecuritiesAsync()
        {
            return new ServiceResponse<List<Security>>
            {
                Data = await _context.Securities.ToListAsync()
            };
        }

        public async Task<ServiceResponse<int>> CreateSecurityAsync(Security security)
        {
            _context.Securities.Add(security);
            int result = await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = result,
                Success = result > 0
            };
        }
    }
}
