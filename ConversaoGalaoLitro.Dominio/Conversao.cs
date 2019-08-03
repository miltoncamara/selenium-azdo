using System;

namespace ConversaoGalaoLitro.Dominio
{
    public class Conversao
    {
        public double GalaoParaLitros(double galoes)
        {
            //return galoes * 3.7854;
            return Math.Round(galoes * 3.7854, 4);
        }
    }
}
