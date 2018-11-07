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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapptesy.Models
{
    public class DayWithNoAvailability
    {
        public int Id { get; set; }

        // one to one relation with invoice rows

        public int CurrentInvoiceRowId { get; set; }
        public InvoiceRows InvoiceRows { get; set; }

        [DefaultValue(false)]
        public Boolean MorningLocked { get; set; }

        [DefaultValue(false)]
        public Boolean AfternoonLocked { get; set; }
    }
}
