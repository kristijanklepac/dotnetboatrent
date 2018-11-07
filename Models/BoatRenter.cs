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

namespace webapptesy.Models
{
    public class BoatRenter
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string VatId { get; set; }

        public Boolean HaveBoatLicense { get; set; }

        public string BoatLicenseInfo { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<ProformaInvoice> ProformaInvoices { get; set; }

        public ICollection<Invoice> Invoices { get; set; }


    }
}
