using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapptesy.AccountViewModels;
using webapptesy.Data;
using webapptesy.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapptesy.Controllers
{
    [Route("api/[controller]")]
    public class BoatsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public BoatsController(ApplicationDbContext context)
        {

            _context = context;
        }

        // GET: api/boats
        [HttpGet]
        public IEnumerable<Boat> Get()
        {
            return _context.Boats.OrderBy(b => b.Id);
        }

        // GET api/boats/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoat([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boat = await _context.Boats.SingleOrDefaultAsync(o => o.Id == id);

            if (boat == null)
            {
                return NotFound();
            }
            return Ok(boat);
        }

        // POST api/boats
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BoatsViewModel boatsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boat = new Boat
            {
                BoatName = boatsViewModel.BoatName,
                DescriptionDe = boatsViewModel.DescriptionDe,
                DescriptionEn = boatsViewModel.DescriptionEn,
                DescriptionHr = boatsViewModel.DescriptionHr,
                DescriptionIt = boatsViewModel.DescriptionIt,
                ContentDe = boatsViewModel.ContentDe,
                ContentEn = boatsViewModel.ContentEn,
                ContentIt = boatsViewModel.ContentIt,
                ContentHr = boatsViewModel.ContentHr,
                Active = true,
                Category = boatsViewModel.Category,
                Motor = boatsViewModel.Motor,
                Fuel = boatsViewModel.Fuel,
                Speed = boatsViewModel.Speed,
                Water = boatsViewModel.Water,
                Width = boatsViewModel.Width,
                Weight = boatsViewModel.Weight,
                Length = boatsViewModel.Length,
                NrPersons = boatsViewModel.NrPersons,
                GoogleCalendarId = ""
            };

                _context.Boats.Add(boat);
                await _context.SaveChangesAsync();


            return Ok(boat);

        }

        // PUT api/boats/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/boats/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
