//
//  Author:
//    Kristijan Klepač kristijan.klepac@gmail.com
//
//  Copyright (c) 2018, www.kristijanklepac.info
//
//  All rights reserved.
//
//
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
    public class OwnersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public OwnersController(ApplicationDbContext context) {

            _context = context;
        }

        // GET: api/owners
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _context.Owners.OrderBy(o => o.Id);
        }

        // GET api/owners/5 // return only name
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _context.Owners.SingleOrDefaultAsync(o => o.Id == id);

            if(owner == null) {
                return NotFound();
            }
            return Ok(owner);
        }

        // GET api/owners/5 // return full data
        [HttpGet("full/{id}")]
        public async Task<IActionResult> GetFullOwner([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _context.Owners.Include(e => e.Address).SingleOrDefaultAsync(o => o.Id == id); 

            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        // POST api/owners
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OwnerViewModel ownerVievModel)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var owner = new Owner
            {
                Name = ownerVievModel.Name,
                Address = new OwnerAddress
                {
                    Address = ownerVievModel.OwnerAddress,
                    Country = ownerVievModel.Country,
                    State = ownerVievModel.State,
                    City = ownerVievModel.City,
                    Email = ownerVievModel.Email,
                    Phone1 = ownerVievModel.Phone1,
                    Phone2 = ownerVievModel.Phone2,
                }
            };

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return Ok(owner);

        }

        // PUT api/owners/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
