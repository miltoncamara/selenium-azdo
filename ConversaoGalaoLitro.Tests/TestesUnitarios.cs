using ConversaoGalaoLitro.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConversaoGalaoLitro.Tests
{
    [TestClass]
    public class TestesUnitarios
    {
        [TestMethod]
        [DataRow(1, 3.7854)]
        [DataRow(2, 7.5708)]
        [DataRow(3, 11.3562)]
        [TestCategory("TestesUnitarios")]
        public void CalcularGaloesParaLitro_Unit(double galoes, double resultadoEsperado)
        {
            var conversao = new Conversao();
            var resultado = conversao.GalaoParaLitros(galoes);
            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
