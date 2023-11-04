using System.ComponentModel.DataAnnotations;

namespace DonutQueenAPI.Models
{
    public class Donut
    {
        public string? Afbeelding { get; set; }
        public int DonutId { get; set; }

        public string? Glazuur { get; set; }
        public bool? IsVegan { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Omschrijving { get; set; }

        public string? Topping { get; set; }
        public string? Vulling { get; set; }
        public int? WinkelId { get; set; }
    }
}