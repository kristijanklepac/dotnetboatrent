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
    public class DayWithInterest
    {
        public int Id { get; set; }

        // one to one relation with proforma invoice rows

        public int CurrentProformaInvoiceRowId { get; set; }
        public ProformaInvoiceRows ProformaInvoiceRows { get; set; }

        [DefaultValue(false)]
        public Boolean MorningLocked { get; set; }

        [DefaultValue(false)]
        public Boolean AfternoonLocked { get; set; }


    }
}
