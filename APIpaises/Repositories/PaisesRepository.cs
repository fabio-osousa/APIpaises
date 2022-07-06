using APIpaises.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIpaises.Repositories
{
    public class PaisesRepository : IPaisesRepository
    {
        public readonly PaisesContext _context;
        public PaisesRepository(PaisesContext context)
        {
            _context = context;
        }
        public async Task<Paises> Create(Paises paises)
        {
            _context.Paises.Add(paises);
            await _context.SaveChangesAsync();

            return paises;
        }

        public async Task Delete(int id)
        {
            var paisesToDelete = await _context.Paises.FindAsync(id);
            _context.Paises.Remove(paisesToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Paises>> Get()
        {
            return await _context.Paises.ToListAsync();
        }

        public async Task<Paises> Get(int id)
        {
            return await _context.Paises.FindAsync(id);
        }

        public async Task Updade(Paises paises)
        {
            _context.Entry(paises).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
