using ElectroniqueApi.Model;
using System.ComponentModel.DataAnnotations;

namespace ElectroniqueApi.Dto
{
    public class ProduitDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Désignation { get; set; }
        [Required]
       
        public float Prix { get; set; }
        [Required]
       
        public int Quantite { get; set; }
        public int? LigneFactureId { get; set; }

        public string photo { get; set; }
        public byte CategorieId { get; set; }

        public Categorie? Categorie { get; set; }
    }
}
