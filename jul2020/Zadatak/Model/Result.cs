using System.Collections.Generic;

namespace Zadatak.Models
{
    public class Result
    {
        public int Id { get; set; }

        public bool IsOver { get; set; }

        public byte CurrentSet { get; set; }

        public IList<Set> Sets { get; set; }

        public int MatchId { get; set; }

        public Match Match { get; set; }
    }
}