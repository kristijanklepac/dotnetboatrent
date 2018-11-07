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
    public class BoatImage
    {
        public int Id { get; set; }

        public String ImageAltHr { get; set; }

        public String ImageAltDe { get; set; }

        public String ImageAltEn { get; set; }

        public String ImageAltIt { get; set; }

        public String OrigImage { get; set; }

        public String ImageXlUrl { get; set; }

        public String ImageMdUrl { get; set; }

        public String ImageSmUrl { get; set; }

        public String ImageLgUrl { get; set; }

        public String ImageCaptionHr { get; set; }

        public String ImageCaptionDe { get; set; }

        public String ImageCaptionEn { get; set; }

        public String ImageCaptionIt { get; set; }

        public String ImageTitleHr { get; set; }

        public String ImageTitleDe { get; set; }

        public String ImageTitleEn { get; set; }

        public String ImageTitleIt { get; set; }

        public String Name { get; set; }

        // can be gallim or vertim or panim
        public String BelongsTo { get; set; }

        public int Orderx { get; set; }

        public Boolean Active { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public int CurrentBoatId { get; set; }
        public Boat Boat { get; set; }
    }
}
