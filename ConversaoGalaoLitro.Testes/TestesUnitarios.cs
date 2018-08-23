using ConversaoGalaoLitro.Dominio;
using System;
using System.Linq;
using Xunit;

namespace ConversaoGalaoLitro.Testes
{
    public class TestesUnitarios
    {
        [Theory]
        [InlineData(1, 3.7854)]
        [InlineData(2, 7.5708)]
        [InlineData(3, 11.3562)]
        [Trait("Category", "TestesUnitarios")]
        public void CalcularGaloesParaLitro(double galoes, double resultadoEsperado)
        {
            var conversao = new Conversao();
            var resultado = conversao.GalaoParaLitros(galoes);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
