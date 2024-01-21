using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElectroniqueApi.Model
{
    public class Facture
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
        public List<LigneFacture> ligneFacture { get; set; }

        public double Price { get; set; }
    }
}
