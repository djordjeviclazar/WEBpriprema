using System;
using System.Collections.Generic;

namespace Prvi.Models
{
    public class Fabrika
    {
        public int Id { get; set; }

        public String Ime { get; set; }

        public List<Silos> Silosi { get; set; }

        public int brojSilosa { get; set; }
    }
}