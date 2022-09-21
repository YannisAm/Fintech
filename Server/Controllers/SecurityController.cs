using Fintech.Server.Data;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly DataContext _context;

        public SecurityController(DataContext context)
        {
            _context = context; 
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Security>>>> GetSecurity ()
        {
            var securities = await _context.Securities.ToListAsync();
            var response = new ServiceResponse<List<Security>>()
            {
                Data = securities
            };
            return Ok(response);
        }
    }
}
