using System;
using DTOs;
using Data.Interfaces;
using System.Threading.Tasks;

namespace Dominio.Service
{
    public class ArticulosServicio
    {

        private readonly IAutorRepository _autorRepository;
        private readonly IArticulosRepository _articuloRepository;

        public ArticulosServicio(IArticulosRepository articulosRepository, IAutorRepository autorRepository)
        {
            _articuloRepository = articulosRepository;
            _autorRepository = autorRepository;
        }


        public async Task<Articulo> InsertarArticuloAsync(string contenido, string titulo, int autorId)
        {
            if (! await _autorRepository.AutorValidoAsync(autorId))
            {
                throw new Exception("Autor not valido");
            }


            var articuloId = await _articuloRepository.InsertarArticuloAsync(contenido, titulo, autorId);

            return await ConsultarArticuloAsync(articuloId);
        }

        public async Task<Articulo> ConsultarArticuloAsync(int id)
        {
            return await _articuloRepository.GetArticuloAsync(id);
        }

    }

}
