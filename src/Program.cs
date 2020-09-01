using System;
using ClassificadorDeTextos.Model;

namespace ClassificadorDeTextos
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelo1 = BagOfWords.DoArquivo("textos/like-a-stone.txt", "Audioslave - Like a stone");
            var modelo2 = BagOfWords.DoArquivo("textos/if-only-two.txt");

            modelo1.ImprimiNoConsole();
            modelo2.ImprimiNoConsole();

            var distancia = modelo1.DistanciaAte(modelo2);
            Console.WriteLine(distancia);

            var media = BagOfWords.Media(new BagOfWords[]
            {
                modelo1,
                modelo2
            }, "Média entre Audioslave e Unida");

            media.ImprimiNoConsole();
        }
    }
}
