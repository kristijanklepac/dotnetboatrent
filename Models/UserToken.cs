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
    public class UserToken
    {
        public int Id { get; set; }
        public string TokenName { get; set; }
        public string TokenValue { get; set; }
        public string Email { get; set; }
        public string UserFolder { get; set; }
    }
}
