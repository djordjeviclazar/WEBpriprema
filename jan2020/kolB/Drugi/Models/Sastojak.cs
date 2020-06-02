using System;

namespace Drugi.Data
{
    public class Sastojak
    {
        public int Id { get; set; }
        
        public String Naziv { get; set; }

        public int Kolicina { get; set; }

        public String Jedinica { get; set; }

        public bool PoPotrebi { get; set; }
    }
}