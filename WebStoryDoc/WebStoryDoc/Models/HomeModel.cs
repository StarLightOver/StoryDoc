﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebStoryDoc.Models
{
    public class HomeModel
    {
        [DisplayName("Название страницы")]
        public string Title { get; set; }

        public DateTime Time { get; set; }
    }
}