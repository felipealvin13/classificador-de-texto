using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClassificadorDeTextos.IO
{
    class LeitorDeArquivos
    {
        string caminhoArquivo;

        public LeitorDeArquivos(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public IDictionary<string, int> ExtraiModelo()
        {
            var modelo = new Dictionary<string, int>();
            var separadores = new char[] { ',', ' ', '?', '!', '.' };    

            using (var leitor = new StreamReader(caminhoArquivo))
            {
                string linha;

                while ((linha = leitor.ReadLine()) != null)
                {
                    var palavras = linha
                        .ToLower()
                        .Split(separadores, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string palavra in palavras)
                    {
                        int encontrados = 0;
                        modelo.TryGetValue(palavra, out encontrados);
                        modelo[palavra] = ++encontrados;
                    }
                }
            }

            return modelo;
        }

    }

}
