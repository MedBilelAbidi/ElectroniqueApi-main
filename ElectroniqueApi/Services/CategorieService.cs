using ElectroniqueApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ElectroniqueApi.Services
{
    public class CategorieService : ICategorieService<Categorie>
    {
        private readonly AppDbContext context;
        public CategorieService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Categorie> Add(Categorie t)
        {

            var result = await this.context.Categories.AddAsync(t);
          await  this.context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Categorie> Delete(int Id)
        {
            var p = await this.context.Categories.FirstOrDefaultAsync( e => e.Id == Id);
            if (p != null)
            {
                context.Categories.Remove(p);
             await   this.context.SaveChangesAsync();
                return p;
            }
            return null;
        }

        public async Task<Categorie> Get(int Id)
        {
            return await this.context.Categories.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Categorie>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Categorie> Update(Categorie t)
        {
            var p = await context.Categories.FirstOrDefaultAsync(
            e => e.Id == t.Id);
            if (p != null)
            {
             p.Designation = t.Designation;

                await context.SaveChangesAsync();
                return p;
            }
            return null;
        }
    }
}
