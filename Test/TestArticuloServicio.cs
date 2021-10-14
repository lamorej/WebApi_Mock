
using Data.Interfaces;
using Dominio.Service;
using DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class TestArticulosServicio
    {
        [TestMethod]
        public async Task TestMethod_InsertarArticulo()
        {
            string contenido = "contenido";
            string titulo = "titulo";
            int autorId = 1;

            Mock<IArticulosRepository> articuloRepo = new Mock<IArticulosRepository>();
            Mock<IAutorRepository> autorRepo = new Mock<IAutorRepository>();
            autorRepo.Setup(a => a.AutorValidoAsync(It.IsAny<int>())).Returns(Task.FromResult(true));

            articuloRepo.Setup(a => a.InsertarArticuloAsync(contenido, titulo, autorId)).Returns(Task.FromResult(1));
            articuloRepo.Setup(a => a.GetArticuloAsync(1)).Returns(Task.FromResult(new Articulo()
            {
                Autor = new Autor()
                {
                    AutorId = autorId,
                    Nombre = "test"
                },
                Contenido = contenido,
                Fecha = DateTime.UtcNow,
                Id = 1,
                Titulo = titulo
            }));

            ArticulosServicio servicio = new ArticulosServicio(articuloRepo.Object, autorRepo.Object);
            Articulo articulo = await servicio.InsertarArticuloAsync(contenido, titulo, autorId);

            Assert.AreEqual(autorId, articulo.Autor.AutorId);
            autorRepo.Verify(a => a.AutorValidoAsync(It.IsAny<int>()));

            articuloRepo.Verify(a => a.InsertarArticuloAsync(contenido, titulo, autorId));
            articuloRepo.Verify(a => a.GetArticuloAsync(1));

        }
    }
}
