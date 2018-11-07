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
    public class BoatCalendarDateRangeViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-DD")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-DD")]
        public DateTime EndDate { get; set; }

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
