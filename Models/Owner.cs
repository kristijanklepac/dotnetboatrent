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

namespace webapptesy.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public OwnerAddress Address { get; set; }
    }
}
