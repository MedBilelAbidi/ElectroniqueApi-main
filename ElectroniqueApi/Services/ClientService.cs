using ElectroniqueApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ElectroniqueApi.Services
{
    public class ClientService : ICllientService<Client>
    {
        private readonly AppDbContext context;
        public ClientService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Client> Add(Client t)
        {
            var result = await this.context.Clients.AddAsync(t);
            await this.context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Client> Delete(int Id)
        {
            var p = await this.context.Clients.FirstOrDefaultAsync(e => e.Id == Id);
            if (p != null)
            {
                context.Clients.Remove(p);
                await this.context.SaveChangesAsync();
                return p;
            }
            return null;
        }

        public async Task<Client> Get(int Id)
        {
            return await this.context.Clients.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await context.Clients.ToListAsync();
        }

        public async Task<Client> Update(Client t)
        {
            var p = await context.Clients.FirstOrDefaultAsync(e => e.Id == t.Id);
            if (p != null)
            {
                context.Entry(t).State = EntityState.Modified;

                await context.SaveChangesAsync();
                return p;
            }
            return null;
        }
    }
}
  