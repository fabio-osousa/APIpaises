using APIpaises.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIpaises.Repositories
{
    public interface IPaisesRepository
    {
        Task<IEnumerable<Paises>> Get();

        Task<Paises> Get(int Id);

        Task<Paises> Create(Paises paises);

        Task Updade(Paises paises);

        Task Delete(int Id); 

    }
}
