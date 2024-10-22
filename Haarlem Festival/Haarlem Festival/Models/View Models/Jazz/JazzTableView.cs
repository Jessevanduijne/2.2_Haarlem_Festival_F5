﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models.Jazz
{
    public class JazzTableView
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Band { get; set; }
        public string Price { get; set; }
    }
}