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

        [HttpGet("findUser/{email}")]
        public async Task<ActionResult<ServiceResponse<List<Security>>>> GetSecurities(string email)
        {
            var result = await _securityService.GetSecuritiesAsync(email);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Security>>> GetSecurityById([FromRoute] int id)
        {
            var result = await _securityService.GetSecurityByIdAsync(id);
            return Ok(result);
        }

        


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
    }
}
