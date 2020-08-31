using System;
using System.IO;
using ClassificadorDeTextos.IO;
using ClassificadorDeTextos.Comparadores;

namespace ClassificadorDeTextos
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelo1 = new LeitorDeArquivos("textos/like-a-stone.txt").ExtraiModelo();
            var modelo2 = new LeitorDeArquivos("textos/if-only-two.txt").ExtraiModelo();

            foreach (var entrada in modelo1)
                Console.WriteLine(entrada);

            foreach (var entrada in modelo2)
                Console.WriteLine(entrada);

            var distancia = new ComparadorSimples().CalculaDistancia(modelo1, modelo2);

            Console.WriteLine(distancia);
        }
    }
}
