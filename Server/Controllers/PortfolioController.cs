using Fintech.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Portfolio>>>> GetPortfolios()
        {
            var result = await _portfolioService.GetPortfoliosAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Portfolio>>> GetPortfolioById([FromRoute] int id)
        {
            var result = await _portfolioService.GetPortfolioByIdAsync(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> CreatePortfolio(Portfolio portfolio)
        {
            var result = await _portfolioService.CreatePortfolioAsync(portfolio);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<int>>> EditPortfolio(Portfolio portfolio)
        {
            var result = await _portfolioService.EditPortfolioAsync(portfolio);
            return Ok(result);
        }

        [HttpDelete("{portfolioId}")]
        public async Task<ActionResult<ServiceResponse<int>>> DeletePortfolio([FromRoute] int portfolioId)
        {
            var result = await _portfolioService.DeletePortfolioAsync(portfolioId);
            return Ok(result);
        }

    }
}
