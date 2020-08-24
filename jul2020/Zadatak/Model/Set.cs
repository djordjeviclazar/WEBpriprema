using Zadatak.Helpers.Enums;

namespace Zadatak.Models
{
    public class Set
    {
        public int Id { get; set; }
        public short Player1GemsWon { get; set; }

        public short Player2GemsWon { get; set; }

        public short Player1Points { get; set; }

        public short Player2Points { get; set; }

        public bool WithTieBreak { get; set; }

        public Result Result { get; set; }
    }
}