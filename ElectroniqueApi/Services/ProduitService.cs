using ElectroniqueApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ElectroniqueApi.Services
{
    public class ProduitService : IProduitService<Produit>
    {
        private readonly AppDbContext context;
        public ProduitService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Produit> Add(Produit t)
        {
            var result = await context.Products.AddAsync(t);
           await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Produit> Delete(int Id)
        {
            var p = await context.Products.FirstOrDefaultAsync(
            e => e.Id == Id);
            if (p != null)
            {
                context.Products.Remove(p);
               await context.SaveChangesAsync();
                return p;
            }
            return null;

        }

        public async Task<Produit> GetProduit(int Id)
        {
            return await context.Products.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Produit>> GetAll()
        {
            return await context.Products.ToListAsync();
        }


        public async Task<Produit> Update(Produit t, int id)
        {
            var p = await this.context.Products.FirstOrDefaultAsync(
            e => e.Id == t.Id);
            if (p != null)
            {
                p.Designation = t.Designation;
                p.Categorie = t.Categorie;
                p.CategorieId = t.CategorieId;
                p.Prix = t.Prix;
                p.Quantite = t.Quantite;
                p.photo = t.photo;


               await context.SaveChangesAsync();
                return p;
            }
            return null;
        }

        public async Task<Produit> Get(int Id)
        {
            return await this.context.Products.FirstOrDefaultAsync(e => e.Id == Id);
        }
    }


}
