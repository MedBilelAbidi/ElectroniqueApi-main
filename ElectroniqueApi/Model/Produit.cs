using System.ComponentModel.DataAnnotations;

namespace ElectroniqueApi.Model
{
    public class Produit
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Designation { get; set; }
        [Required]
        public float Prix { get; set; }
        [Required]
        public int Quantite { get; set; }

        public string photo { get; set; }

        public int CategorieId { get; set; }

        public Categorie? Categorie { get; set; }
    }
}
