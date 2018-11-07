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
using System.ComponentModel.DataAnnotations.Schema;

namespace webapptesy.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public string InvoiceDescription { get; set; }

        public int InvoiceBoatRenterId { get; set; }

        public BoatRenter BoatRenter { get; set; }

        public ICollection<InvoiceRows> AllInvoiceRows { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
