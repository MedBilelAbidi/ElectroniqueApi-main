using ElectroniqueApi.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ElectroniqueApi.Services
{
    public class FactureService : IFactureService<Facture>
    {
        private readonly AppDbContext context;

        public FactureService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Facture> Add(Facture t)
        {
            
            var result = await context.Factures.AddAsync(t);
             await  context.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<Facture> Delete(int Id)
        {
            var p = await this.context.Factures.FirstOrDefaultAsync(e => e.Id == Id);
            if (p != null)
            {
                context.Factures.Remove(p);
                await context.SaveChangesAsync();
                return p;
            }
            return null;
        }

        public async Task<Facture> Get(int Id)
        {
            return await this.context.Factures.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Facture>> GetAll()
        {
            return await context.Factures.Include(o=> o.Client).Include(o=> o.ligneFacture).ToListAsync();
        }

        public async Task<Facture> Update(Facture t)
        {
            var p = await this.context.Factures.FirstOrDefaultAsync(e => e.Id == t.Id);
            if (p != null)
            {
              
                p.DateTime = t.DateTime;

                await context.SaveChangesAsync();

                foreach (var item in t.ligneFacture)
                {
                    if (item.Id == null)
                    {
                        // update product quantity
                        var prodduit = await context.Products.FirstOrDefaultAsync(p => p.Id == item.ProduitId);
                        if (prodduit != null)
                        {
                            prodduit.Quantite -= item.quantite;
                        }
                        item.FactureId = p.Id;
                        await context.LignesFactures.AddAsync(item);
                    }
                    else
                    {
                        // update product quantity
                        var prodduit = await context.Products.FirstOrDefaultAsync(p => p.Id == item.ProduitId);
                        var oldLigneFactue = p.ligneFacture.FirstOrDefault(p => p.Id == item.Id);

                        if (prodduit != null)
                        {
                            prodduit.Quantite += oldLigneFactue!.quantite;
                            prodduit.Quantite -= item.quantite;
                        }
                        context.Entry(item).State = EntityState.Modified;
                    }
                }
                await context.SaveChangesAsync();
                return p;
            }
            return null;
        }
    }
}
