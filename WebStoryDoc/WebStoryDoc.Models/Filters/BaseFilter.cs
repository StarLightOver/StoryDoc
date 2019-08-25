﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models.Filters
{
    public abstract class BaseFilter
    {
        public long?  Id { get; set; }

        //Супер поисковая строка
        public string SearchString { get; set; }
    }
}
