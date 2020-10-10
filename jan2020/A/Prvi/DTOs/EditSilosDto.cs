using System.ComponentModel.DataAnnotations;

namespace Prvi.Dtos
{
    public class EditSilosDto
    { 
        public int Id { get; set; }
        [Range(1, 10000)]
        public int Kolicina { get; set; }
    }
}