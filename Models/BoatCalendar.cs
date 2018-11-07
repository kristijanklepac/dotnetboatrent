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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace webapptesy.Models
{
    public class BoatCalendar
    {
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BookDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal FullDayPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MorningPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal AfternoonPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal SevenDaysPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal FourteenDaysPrice { get; set; }

        public int CalendarBoatId { get; set; }
        public Boat Boat { get; set; }
    }
}
