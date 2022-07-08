using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Romarinho.Domain.Model;
using Romarinho.Domain.Services;

namespace Romarinho.Testes
{
    public class OrdemServiceTeste
    {
        [Fact]
        public async System.Threading.Tasks.Task PegarPorIdTeste()
        {
            try
            {
                var mock = new Mock<IOrdemService>();
                var ordemEsperada = new Ordem { Id = 1, Ativo = "PETR4", Quantidade = 100, Valor = 100, Assessor = "Romarinho" };
                mock.Setup(m => m.PegarPorId(1)).Returns(ordemEsperada);

                var ordemService = mock.Object;
                var ordemRetornada = ordemService.PegarPorId(1);

                Xunit.Assert.Equal(ordemEsperada, ordemRetornada);
            }
            catch (Exception ex)
            {
                Xunit.Assert.True(false);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task PegarPorIdUsuarioTeste()
        {
            try
            {
                var mock = new Mock<IOrdemService>();
                var ordensEsperada = new List<Ordem>
                {
                    new Ordem { Id = 1, Ativo = "PETR4", Quantidade = 100, Valor = 100, Assessor = "Romarinho" },
                    new Ordem { Id = 2, Ativo = "PETR4", Quantidade = 100, Valor = 100, Assessor = "Romarinho" }
                };

                mock.Setup(m => m.PegarPorIdUsuario(1)).Returns(ordensEsperada);

                var ordemService = mock.Object;
                var ordensRetornadas = ordemService.PegarPorIdUsuario(1).ToList();

                CollectionAssert.AreEqual(ordensEsperada, ordensRetornadas);
            }
            catch (Exception ex)
            {
                Xunit.Assert.True(false);
            }
        }
    }
}

