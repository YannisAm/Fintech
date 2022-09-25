using Microsoft.AspNetCore.Components;

namespace Fintech.Client
{
    public class NavigateToPortfolio
    {
        public NavigationManager? NavigationManager { get; set; }
        public void Navigate()
        {
            NavigationManager.NavigateTo("/portfolio", true);
        }
    }
}
