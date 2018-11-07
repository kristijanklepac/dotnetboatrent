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

namespace webapptesy.Controllers
{
    [Route("api/[controller]")]
    public class BoatCalendarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoatCalendarsController(ApplicationDbContext context)
        {

            _context = context;
        }

        // GET: api/boatcalendars
        [HttpGet]
        public IEnumerable<BoatCalendar> Get()
        {
            return _context.BoatCalendars.OrderBy(b => b.Id);
        }

        // GET api/boatcalendars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoatCalendar([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boatCalendar = await _context.BoatCalendars.SingleOrDefaultAsync(bc => bc.Id == id);

            if (boatCalendar == null)
            {
                return NotFound();
            }
            return Ok(boatCalendar);
        }

        // POST api/boatcalendars
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BoatCalendarViewModel boatCalendarViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // find a boat by given calendarboatid
            var boat = await _context.Boats.SingleOrDefaultAsync(o => o.Id == boatCalendarViewModel.CalendarBoatId);

            if (boat == null)
            {
                return NotFound();
            }

            // find row in table (if exists) for that date (table BoatCalendars) -> this boat id
            // if exists update
            // if not insert

            var boatCalendar = await _context.BoatCalendars.FirstOrDefaultAsync(
                o => o.CalendarBoatId == boatCalendarViewModel.CalendarBoatId 
                && o.BookDate == boatCalendarViewModel.BookDate);

            if (boatCalendar == null)
            {

                boatCalendar = new BoatCalendar
                {

                    BookDate = boatCalendarViewModel.BookDate,
                    FullDayPrice = boatCalendarViewModel.FullDayPrice,
                    MorningPrice = boatCalendarViewModel.MorningPrice,
                    AfternoonPrice = boatCalendarViewModel.AfternoonPrice,
                    FourteenDaysPrice = boatCalendarViewModel.FourteenDaysPrice,
                    SevenDaysPrice = boatCalendarViewModel.SevenDaysPrice,
                    CalendarBoatId = boatCalendarViewModel.CalendarBoatId,
                    Boat = boat
                };

                _context.BoatCalendars.Add(boatCalendar);
                await _context.SaveChangesAsync();

            }
            else {

                // only this fields are allowed for update

                var oldFullDayPrice = boatCalendar.FullDayPrice;
                var oldMorningPrice = boatCalendar.MorningPrice;
                var oldAfternoonPrice = boatCalendar.AfternoonPrice;
                var oldFourteenDaysPrice = boatCalendar.FourteenDaysPrice;
                var oldSevenDaysPrice = boatCalendar.SevenDaysPrice;

                var oldCalendarBoatId = boatCalendar.CalendarBoatId;
                var oldBookDate = boatCalendar.BookDate;

                // remove old row -> not needed we insert new one

                _context.Remove(boatCalendar);
                _context.SaveChanges();

                boatCalendar = new BoatCalendar { };

                boatCalendar.BookDate = oldBookDate;

                boatCalendar.FullDayPrice = ChangeOrNot(oldFullDayPrice, boatCalendarViewModel.FullDayPrice) ? boatCalendarViewModel.FullDayPrice : oldFullDayPrice;
                boatCalendar.MorningPrice = ChangeOrNot(oldMorningPrice, boatCalendarViewModel.MorningPrice) ? boatCalendarViewModel.MorningPrice : oldMorningPrice;
                boatCalendar.AfternoonPrice = ChangeOrNot(oldAfternoonPrice, boatCalendarViewModel.AfternoonPrice) ? boatCalendarViewModel.AfternoonPrice : oldAfternoonPrice;
                boatCalendar.FourteenDaysPrice = ChangeOrNot(oldFourteenDaysPrice, boatCalendarViewModel.FourteenDaysPrice) ? boatCalendarViewModel.FourteenDaysPrice : oldFourteenDaysPrice;
                boatCalendar.SevenDaysPrice = ChangeOrNot(oldSevenDaysPrice, boatCalendarViewModel.SevenDaysPrice) ? boatCalendarViewModel.SevenDaysPrice : oldSevenDaysPrice;


                boatCalendar.CalendarBoatId = oldCalendarBoatId;
                boatCalendar.Boat = boat;



                _context.BoatCalendars.Add(boatCalendar);
                await _context.SaveChangesAsync();

            };

            return Ok(boatCalendar);
        }

        // POST api/boatcalendars
        // only for date ranges dateStart->dateEnd
        [HttpPost("{id}")]
        public async Task<IActionResult> PostDateRange([FromBody] BoatCalendarDateRangeViewModel boatCalendarDateRangeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // find a boat by given calendarboatid
            var boat = await _context.Boats.SingleOrDefaultAsync(o => o.Id == boatCalendarDateRangeViewModel.CalendarBoatId);

            if (boat == null)
            {
                return NotFound();
            }

            // find row in table (if exists) for that date (table BoatCalendars) -> this boat id
            // if exists update
            // if not insert

            var dateX = boatCalendarDateRangeViewModel.StartDate;
            Boolean dateloop = true;
            int maxloop = 365; // set here how many days can be in range max
            int brojac = 0;

            while (dateloop)
            {
                var boatCalendar =_context.BoatCalendars.FirstOrDefault(
                o => o.CalendarBoatId == boatCalendarDateRangeViewModel.CalendarBoatId
                && o.BookDate == dateX);



                if (boatCalendar == null)
                {

                    boatCalendar = new BoatCalendar
                    {

                        BookDate = dateX,
                        FullDayPrice = boatCalendarDateRangeViewModel.FullDayPrice,
                        MorningPrice = boatCalendarDateRangeViewModel.MorningPrice,
                        AfternoonPrice = boatCalendarDateRangeViewModel.AfternoonPrice,
                        FourteenDaysPrice = boatCalendarDateRangeViewModel.FourteenDaysPrice,
                        SevenDaysPrice = boatCalendarDateRangeViewModel.SevenDaysPrice,
                        CalendarBoatId = boatCalendarDateRangeViewModel.CalendarBoatId,
                        Boat = boat
                    };

                    _context.BoatCalendars.Add(boatCalendar);
                    await _context.SaveChangesAsync();

                }
                else
                {

                    // only this fields are allowed for update

                    var oldFullDayPrice = boatCalendar.FullDayPrice;
                    var oldMorningPrice = boatCalendar.MorningPrice;
                    var oldAfternoonPrice = boatCalendar.AfternoonPrice;
                    var oldFourteenDaysPrice = boatCalendar.FourteenDaysPrice;
                    var oldSevenDaysPrice = boatCalendar.SevenDaysPrice;

                    var oldCalendarBoatId = boatCalendar.CalendarBoatId;
                    var oldBookDate = boatCalendar.BookDate;

                    // remove old row -> not needed we insert new one

                    _context.Remove(boatCalendar);
                    _context.SaveChanges();

                    boatCalendar = new BoatCalendar { };

                    boatCalendar.BookDate = oldBookDate;

                    boatCalendar.FullDayPrice = ChangeOrNot(oldFullDayPrice, boatCalendarDateRangeViewModel.FullDayPrice) ? boatCalendarDateRangeViewModel.FullDayPrice : oldFullDayPrice;
                    boatCalendar.MorningPrice = ChangeOrNot(oldMorningPrice, boatCalendarDateRangeViewModel.MorningPrice) ? boatCalendarDateRangeViewModel.MorningPrice : oldMorningPrice;
                    boatCalendar.AfternoonPrice = ChangeOrNot(oldAfternoonPrice, boatCalendarDateRangeViewModel.AfternoonPrice) ? boatCalendarDateRangeViewModel.AfternoonPrice : oldAfternoonPrice;
                    boatCalendar.FourteenDaysPrice = ChangeOrNot(oldFourteenDaysPrice, boatCalendarDateRangeViewModel.FourteenDaysPrice) ? boatCalendarDateRangeViewModel.FourteenDaysPrice : oldFourteenDaysPrice;
                    boatCalendar.SevenDaysPrice = ChangeOrNot(oldSevenDaysPrice, boatCalendarDateRangeViewModel.SevenDaysPrice) ? boatCalendarDateRangeViewModel.SevenDaysPrice : oldSevenDaysPrice;


                    boatCalendar.CalendarBoatId = oldCalendarBoatId;
                    boatCalendar.Boat = boat;



                    _context.BoatCalendars.Add(boatCalendar);
                    await _context.SaveChangesAsync();

                }

                dateX = dateX.AddDays(1);

                brojac++;

                if (dateX > boatCalendarDateRangeViewModel.EndDate)
                {
                    dateloop = false;
                }
                // nesmijemo dozvoliti neograniceni date range odjednom zbog broja requestova ( memory )
                if (brojac >= maxloop)
                {
                    dateloop = false;
                }


            } // while

            // date is changed in each iterration

            return Ok();

        }

        // PUT api/boatcalendars/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/boatcalendars/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public Boolean ChangeOrNot(decimal oldprice, decimal newprice) {

            return oldprice > 0 && newprice > 0 && oldprice != newprice ? true : false;
        }
    }
}
