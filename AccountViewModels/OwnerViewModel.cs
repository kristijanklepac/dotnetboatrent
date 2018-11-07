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
    public class OwnerViewModel
    {

        [Required]
        public string Name { get; set; }

        public string OwnerAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }

       
    }
    
}
