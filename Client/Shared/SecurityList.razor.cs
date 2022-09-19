using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Shared
{
    public partial class SecurityList : ComponentBase
    {
        private static List<Security> Securities = new List<Security>
        {
            new Security
            {
                Id = 1,
                SecurityName = "VUAA",
                Price = 152.69f,
                DateTimeObtained = DateTime.Now,
                Description = "The best ETF"
            },
            new Security
            {
                Id = 2,
                SecurityName = "MSFT",
                Price = 352.42f,
                DateTimeObtained = DateTime.Now,
                Description = "The best MSFT"
            },
            new Security
            {
                Id = 3,
                SecurityName = "APPL",
                Price = 1253.88f,
                DateTimeObtained = DateTime.Now,
                Description ="The best technological company"
            }
        };
    }
}
