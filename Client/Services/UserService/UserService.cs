using Fintech.Shared.Models;
using static System.Net.WebRequestMethods;

namespace Fintech.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient http, IUserService userService)
        {
            _http = http;
        }

        public async Task CreateUser(RegisterUser user)
        {
            var response = await _http.PostAsJsonAsync("api/user", user);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
                if (!(result?.Success ?? false))
                {

                }
            }
        }
    }
}
