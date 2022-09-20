using Fintech.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private static List<Security> Securities = new List<Security>
        {
            new Security
            {
                Id = 1,
                SecurityName = "VUAA",
                Price = 152.69f,
                StockesOwned = 3,
                StocksValue = 458.07f,
                DateTimeObtained = DateTime.Now,
                Description = "The best ETF"
            },
            new Security
            {
                Id = 2,
                SecurityName = "MSFT",
                Price = 352.42f,
                StockesOwned = 10,
                StocksValue = 3524.2f,
                DateTimeObtained = DateTime.Now,
                Description = "The best MSFT"
            },
            new Security
            {
                Id = 3,
                SecurityName = "APPL",
                Price = 1253.88f,
                StockesOwned = 100,
                StocksValue = 12538.8f,
                DateTimeObtained = DateTime.Now,
                Description ="The best technological company"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Security>>> GetSecurity ()
        {
            return Ok(Securities);
        }
    }
}
