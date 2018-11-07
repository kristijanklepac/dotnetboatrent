using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapptesy.Data;
using webapptesy.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapptesy.Controllers
{
    [Route("api/[controller]")]
    public class ExternalTokenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExternalTokenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/externaltoken
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            if (Request.Headers["token"] == "")
            {
                return NotFound();
            }

            var rh = Request.Headers["token"];

            var tokval = await _context.UsersTokens.SingleOrDefaultAsync(tv => tv.TokenValue == rh);

            if (tokval == null)
            {
                return NotFound();
            }
            return Ok(tokval);
        }

    }
}
