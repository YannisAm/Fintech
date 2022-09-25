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

        public async Task<ServiceResponse<Security>> GetSecurityByIdAsync(int id)
        {
            var security = await _context.Securities.FirstOrDefaultAsync(s => s.Id == id);

            return new ServiceResponse<Security>
            {
                Data = security
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

        public async Task<ServiceResponse<int>> EditSecurityAsync(Security security)
        {
            _context.Securities.Update(security);
            int result = await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = result,
                Success = result > 0
            };
        }


        //public Task<ServiceResponse<int>> DeleteSecurityAsync(int securityId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
