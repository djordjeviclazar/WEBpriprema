using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prvi.Models
{
    public class Fabrika
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public String Ime { get; set; }

        public List<Silos> Silosi { get; set; }

        public int brojSilosa { get; set; }
    }
}