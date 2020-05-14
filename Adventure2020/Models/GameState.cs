﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class GameState
    {
        public int HP { get; set; }
        public Room Location { get; set; }
        public double Level { get; set; }
        public int Money { get; set; }
        public int MaxHP { get; set; }
    }
}
