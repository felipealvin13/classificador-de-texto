using System;
using System.IO;
namespace ClassificadorDeTextos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            LeitorDeArquivos leitor = new LeitorDeArquivos(@"D:\Aula C#\Projeto Gabriel\texto.txt");
            var retorno = leitor.ExtrairModelo();
            foreach(var entrada in retorno) 
            {
                Console.WriteLine(entrada);
            }
        }
    }
}
