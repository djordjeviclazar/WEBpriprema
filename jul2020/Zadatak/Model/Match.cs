using System;

namespace Zadatak.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public string Location { get; set; }

        public DateTime Time { get; set; }

        public Result Result { get; set; }
    }
}