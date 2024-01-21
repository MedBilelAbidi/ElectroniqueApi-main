using System.ComponentModel.DataAnnotations;

namespace ElectroniqueApi.Model
{
    public class Categorie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Designation { get; set; } = string.Empty;
        

    }
}
