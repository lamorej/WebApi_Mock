using DTOs;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAutorRepository
    {
        Task<Autor> GetAutorAsync(int id);
        Task<bool>  AutorValidoAsync(int id);
    }
}