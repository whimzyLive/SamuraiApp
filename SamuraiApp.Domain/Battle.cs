using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Samurai> Samurais { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
