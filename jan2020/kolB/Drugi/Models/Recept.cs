using System;
using System.Collections.Generic;

namespace Drugi.Data
{
    public class Recept
    {
        public int Id { get; set; }

        public String Naziv { get; set; }

        public int VremePripreme { get; set; }

        public String Tip { get; set; }

        public List<Sastojak> Sastojci { get; set; }
    }
}