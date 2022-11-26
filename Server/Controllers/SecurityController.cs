using Fintech.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Security>>>> GetSecurities()
        {
            var result = await _securityService.GetSecuritiesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Security>>> GetSecurityById([FromRoute] int id)
        {
            var result = await _securityService.GetSecurityByIdAsync(id);
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<ActionResult<ServiceResponse<List<Security>>>> GetSecurityyById([FromQuery]int id)
        //{
        //    var result = await _securityService.GetSecuritiesAsync();
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> CreateSecurity(Security security)
        {
            var result = await _securityService.CreateSecurityAsync(security);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<int>>> EditSecurity(Security security)
        {
            var result = await _securityService.EditSecurityAsync(security);
            return Ok(result);
        }

        [HttpDelete("{securityId}")]
        public async Task<ActionResult<ServiceResponse<int>>> DeleteSecurity([FromRoute] int securityId)
        {
            var result = await _securityService.DeleteSecurityAsync(securityId);
            return Ok(result);
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Security>>>> SearchSecurities(string searchText)
        {
            var result = await _securityService.SearchSecurity(searchText);
            return Ok(result);
        }

        [HttpGet("search/{searchTextSuggestion}")]
        public async Task<ActionResult<ServiceResponse<List<Security>>>> GetSecuritySearchSuggestion(string searchTextSuggestion)
        {
            var result = await _securityService.GetSecuritySearchSuggestion(searchTextSuggestion);
            return Ok(result);
        }
    }
}
