using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public IAuthService AuthService { get; set; }
        public Fintech.Shared.Models.RegisterUser request { get; set; } = new();

        string message = string.Empty;
        string messageColor = string.Empty;

        public async Task HandleSubmit()
        {
            var result = await AuthService.CreateUser(request);
            message = result.Message;
            if (result.Success)
                messageColor = "text-success";
            else
                messageColor = "text-danger";
        }
    }
}
