﻿using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new();
        public List<Battle> Battles { get; set; } = new();
        public Horse Horse { get; set; }
    }
}
