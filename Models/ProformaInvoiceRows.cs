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
using System.ComponentModel.DataAnnotations.Schema;

namespace webapptesy.Models
{
    public class ProformaInvoiceRows
    {
        // we need to clone fields from calendar 
        // if somebody change prices in calendar we need to be sure that we have 
        // prices that are valid in time of creation of proforma

        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BookDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal FullDayPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MorningPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal AfternoonPrice { get; set; }

        // this price is actually discount full day price if boat is rent min 7 days ( also between 7 and 13 days)
        [Column(TypeName = "decimal(10,2)")]
        public decimal SevenDaysPrice { get; set; }

        // this price is actually discount full day price if boat is rent min 14 days ( also more than 14 days )
        [Column(TypeName = "decimal(10,2)")]
        public decimal FourteenDaysPrice { get; set; }

        public int CalendarBoatId { get; set; } // cloned field no FK

        public string ProformaInvoiceBoatName { get; set; } // cloned field no FK

        public int CurrentProformaInvoiceId { get; set; }
        public ProformaInvoice ProformaInvoice { get; set; }


        // one to one relationship
        public DayWithInterest DayWithInterest { get; set;  }



    }
}
