using DTOs;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IArticulosRepository
    {
     
        Task<int> InsertarArticuloAsync(string contenido, string titulo, int autorId);
        Task<Articulo> GetArticuloAsync(int id);
      
    }
}