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

namespace webapptesy.AccountViewModels
{
    public class BoatCalendarViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-DD")]
        public DateTime BookDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal FullDayPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal MorningPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal AfternoonPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal SevenDaysPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal FourteenDaysPrice { get; set; }

        [Required]
        public int CalendarBoatId { get; set; }
    }
}
