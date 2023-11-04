using System.ComponentModel.DataAnnotations;

namespace DonutQueen.ViewModels.AdminViewModels
{
    public class DonutCreateViewModel
    {
        public int DonutId { get; set; }

        public int? WinkelId { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Omschrijving { get; set; }

        public string? Vulling { get; set; }

        public string? Topping { get; set; }

        public string? Glazuur { get; set; }

        public string? Afbeelding { get; set; }

        public bool? IsVegan { get; set; }

        public IFormFile? Bestand { get; set; }
    }
}
