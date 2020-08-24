using System;
using System.Collections;
using System.Collections.Generic;

namespace Zadatak.Models
{
    public class Player
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public byte Years { get; set; }

        public ushort Rank { get; set; }

        public String Picture { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}