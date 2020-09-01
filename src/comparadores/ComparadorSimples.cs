using System;
using System.Linq;
using System.Collections.Generic;

using BagOfWords = System.Collections.Generic.IDictionary<string, int>;

namespace ClassificadorDeTextos.Comparadores
{
    public class ComparadorSimples 
    {
        public double CalculaDistancia(BagOfWords bag1, BagOfWords bag2) 
        {
            var palavras = bag1.Keys.Concat(bag2.Keys).Distinct();

            double soma = 0;
            
            foreach(var palavra in palavras) 
            {
                int valor1 = 0, valor2 = 0;
                
                bag1.TryGetValue(palavra, out valor1);
                bag2.TryGetValue(palavra, out valor2);

                soma += Math.Pow(valor1 - valor2, 2);
            }

            return Math.Sqrt(soma);
        }

    }
}