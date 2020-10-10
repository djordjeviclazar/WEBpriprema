using System.ComponentModel.DataAnnotations;

namespace Zadatak.Dto
{
    public class MatchEditDTO
    {
        [Required]
        public int MatchId { get; set; }

        [Required]
        public bool Player1Scored { get; set; }
    }
}