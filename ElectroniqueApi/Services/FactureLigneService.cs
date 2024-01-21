using ElectroniqueApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ElectroniqueApi.Services
{
    public class FactureLigneService : IFactureLigneService<LigneFacture>
    {
        private readonly AppDbContext context;
        public FactureLigneService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<LigneFacture>> Add(List<LigneFacture> t)
        {
            foreach (var item in t)
            {
                 await context.LignesFactures.AddAsync(item);
 

            }
            await context.SaveChangesAsync();
            return t;
        }

        public async Task<LigneFacture> Delete(int Id)
        {
            var p = await this.context.LignesFactures.FirstOrDefaultAsync(e => e.Id == Id);
            if (p != null)
            {
                context.LignesFactures.Remove(p);
                await context.SaveChangesAsync();
                return p;
            }
            return null;
        }

        public async Task<LigneFacture> Get(int Id)
        {
            return await context.LignesFactures.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<LigneFacture>> GetAll()
        {
            return await context.LignesFactures.ToListAsync();
        }

        public async Task<LigneFacture> Update(LigneFacture t)
        {
            var p = await this.context.LignesFactures.
                FirstOrDefaultAsync(e => e.Id == t.Id);
            if (p != null)
            {

                context.Entry(t).State = EntityState.Modified;

                await context.SaveChangesAsync();
                return p;
            }
            return null;
        }


        async Task<List<LigneFacture>> IFactureLigneService<LigneFacture>.GetAll()
        {
            return await context.LignesFactures.ToListAsync();
        }

        Task<List<LigneFacture>> IFactureLigneService<LigneFacture>.GetByClinetId(int clientId)
        {
            var ordersForClient = context.LignesFactures.Include(o=> o.Produit)
                .ToListAsync();

            return  ordersForClient;
        }
    }
}
