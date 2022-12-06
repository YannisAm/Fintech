using Fintech.Shared.Models;

namespace Fintech.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<int>> CreateUserAsync(RegisterUser user)
        {
            _context.RegisterUsers.Add(user);
            var result = await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = result,
                Success = result > 0,
                Message = "The user has been saved!"
            };
        }
    }
}
