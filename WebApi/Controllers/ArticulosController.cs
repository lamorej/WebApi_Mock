using Dominio.Service;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ArticulosController : ControllerBase 
    {
        private readonly ArticulosServicio _articulosServicio;
        public ArticulosController(ArticulosServicio articulosServicio)
        {
            _articulosServicio = articulosServicio;
        }

        [HttpPost]
        [Route("Articulo")]
        public async Task<Articulo> InsertarArticuloAsync(string contenido, string titulo, int autor)
        {
            var resultado = await _articulosServicio.InsertarArticuloAsync(contenido, titulo, autor);

            return resultado;
        }

        [HttpGet]
        [Route("Articulo/{id}")]
        public async Task<Articulo> ConsultarArticuloAsync(int id)
        {
            var resultado = await _articulosServicio.ConsultarArticuloAsync(id);

            return resultado;
        }
    }
}