using System;
using System.Collections.Generic;
using System.IO;
namespace ClassificadorDeTextos
{
    class LeitorDeArquivos
    {
        string CaminhoArquivo;
        public LeitorDeArquivos(string CaminhoArquivo)
        {
            this.CaminhoArquivo = CaminhoArquivo;
        }

        public IDictionary<string, int> ExtrairModelo()
        {
            var result = new Dictionary<string, int>();
            if (File.Exists(CaminhoArquivo))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(CaminhoArquivo))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(linha);
                            var palavras = linha.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                            //Console.WriteLine("teste", result.Length);
                            foreach (string palavra in palavras)
                            {
                                
                                int encontrado = 0;
                                if(result.ContainsKey(palavra))
                                {
                                   encontrado = result[palavra];   
                                }
                                result[palavra]= ++encontrado;  
                            }
                           // Console.WriteLine("teste22", result.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            else
            {
                Console.WriteLine("O Arquivo" + CaminhoArquivo + " não foi localizado");
            }
            return result;
        }

    }



}
