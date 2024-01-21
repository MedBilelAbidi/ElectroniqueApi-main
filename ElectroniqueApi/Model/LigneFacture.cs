namespace ElectroniqueApi.Model
{
    public class LigneFacture
    {
        public int Id { get; set; }
        public int ProduitId { get; set; }

        public Produit? Produit { get; set; }
        public int quantite { get; set; }

        public int FactureId { get; set; }
        public Facture? Facture { get; set; }
    }
}
