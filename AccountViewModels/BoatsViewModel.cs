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
    public class BoatsViewModel
    {
        [Required]
        public string BoatName { get; set; }

        public String DescriptionHr { get; set; }

        public String DescriptionDe { get; set; }

        public String DescriptionEn { get; set; }

        public String DescriptionIt { get; set; }

        public String ContentHr { get; set; }

        public String ContentDe { get; set; }

        public String ContentEn { get; set; }

        public String ContentIt { get; set; }

        public String Category { get; set; }

        public String Motor { get; set; }

        public String Speed { get; set; }

        public int NrPersons { get; set; }

        public String Width { get; set; }

        public String Length { get; set; }

        public String Water { get; set; }

        public String Fuel { get; set; }

        public String Weight { get; set; }

        public Boolean Active { get; set; }
    }
}
