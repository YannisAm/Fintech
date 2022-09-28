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
                Success = result > 0,
                Message = "The" + security.SecurityName + "has been saved!"
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

        public async Task<ServiceResponse<int>> DeleteSecurityAsync(int securityId)
        {
            var foundSecurity = await _context.Securities
                .FirstOrDefaultAsync(s => s.Id == securityId);
            _context.Securities.Remove(foundSecurity);
            int result = await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = result,
                Message = "Your security has been deleted"
            };
        }

        public async Task<ServiceResponse<List<Security>>> Searchsecurity(string searchText)
        {
            var response = new ServiceResponse<List<Security>>
            {
                Data = await FindSecuritiesBySearchText(searchText)
            };
            return response;
        }

        private async Task<List<Security>> FindSecuritiesBySearchText(string searchText)
        {
            return await _context.Securities
                                   .Where(s => s.Description.ToLower().Contains(searchText.ToLower())
                                   ||
                                   s.SecurityName.ToLower().Contains(searchText.ToLower()))
                                   .ToListAsync();
        }

        public async Task<ServiceResponse<List<string>>> GetSecuritySearchSuggestion(string searchText)
        {
            var securities = await FindSecuritiesBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var security in securities)
            {
                if (security.SecurityName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(security.SecurityName);
                }

                if (security.Description != null)
                {
                    var punctutation = security.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = security.Description.Split()
                        .Select(s => s.Trim(punctutation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }
    }
}
