using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapptesy.AccountViewModels;
using webapptesy.Data;
using webapptesy.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapptesy.Controllers
{
    [EnableCors("CORSPolicy")]
    [Route("api/[controller]")]
    public class BoatImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoatImagesController(ApplicationDbContext context)
        {

            _context = context;
        }

        // GET: api/boatimages
        [HttpGet]
        public IEnumerable<BoatImage> Get()
        {
            return _context.BoatImages.Where(b=>b.BelongsTo == "gallim").OrderBy(b => b.Orderx);
        }

        // GET: api/boatimages/panim
        [HttpGet("panim")]
        public async Task<IActionResult> GetPanim()
        {
            var panim = await _context.BoatImages.SingleOrDefaultAsync(pi => pi.BelongsTo == "panim");

            if (panim == null)
            {
                return NotFound();
            }

            return Ok(panim);
        }

        // GET: api/boatimages/vertim
        [HttpGet("vertim")]
        public async Task<IActionResult> GetVertim()
        {
            var vertim = await _context.BoatImages.SingleOrDefaultAsync(pi => pi.BelongsTo == "vertim");

            if (vertim == null)
            {
                return NotFound();
            }

            return Ok(vertim);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       

        // POST api/boatimages/position
        [HttpPost("position")]
        public ActionResult<IEnumerable<string>> Post( [FromBody] BoatImagePositionModel boatImagePositionModel)
        {
            return new string[] { boatImagePositionModel.Id.ToString(), boatImagePositionModel.Orderx.ToString() };
        }

        // PUT api/boatimages/position/5
        [HttpPut("position/{id}")]
        public async Task<IActionResult> PutPos([FromRoute] int id,  [FromBody] BoatImagePositionModel boatImagePositionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boatImage = await _context.BoatImages.SingleOrDefaultAsync(pi => pi.Id == id);

            if(boatImage == null)
            {
                return BadRequest();
            }

            boatImage.Orderx = boatImagePositionModel.Orderx;

            _context.Entry(boatImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            return Ok(boatImage);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
