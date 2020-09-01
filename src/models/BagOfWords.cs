using System;
using System.Linq;
using System.Collections.Generic;
using ClassificadorDeTextos.IO;

namespace ClassificadorDeTextos.Model
{
    public class BagOfWords
    {
        public string Nome { get; set; }
        IDictionary<string, int> _ocorrencias;
        
        public BagOfWords() 
        {
            _ocorrencias = new Dictionary<string, int>();
        }
        
        public BagOfWords(IDictionary<string, int> ocorrencias) 
        {
            _ocorrencias = ocorrencias;
        }

        public BagOfWords(string nome, IDictionary<string, int> ocorrencias) 
        {
            Nome = nome;
            _ocorrencias = ocorrencias;
        }

        public static BagOfWords DoArquivo(string caminhoArquivo, string nome=null) => 
            new BagOfWords(nome, new LeitorDeArquivos(caminhoArquivo).ExtraiModelo());  
        

        public int this[string palavra] => _ocorrencias[palavra];

        public ICollection<string> Palavras => _ocorrencias.Keys; 
        
        public void Associa(string palavra, int numOcorrencias) => 
            _ocorrencias[palavra] = numOcorrencias; 

        public bool TentaObterOcorrencias(string palavra, out int numOcorrencias) => 
            _ocorrencias.TryGetValue(palavra, out numOcorrencias);

        public static BagOfWords Media(IEnumerable<BagOfWords> bags, string nome=null) 
        {
            var palavras = bags.SelectMany(bag => bag.Palavras).Distinct();
            var somaDasBags = new BagOfWords { Nome = nome };
            var numeroBags = bags.Count();

            foreach(var palavra in palavras) 
            {
                int somaOcorrencias = 0;

                foreach (var bag in bags)
                {
                    int numOcorrencias = 0;
                    bag.TentaObterOcorrencias(palavra, out numOcorrencias);
                    somaOcorrencias += numOcorrencias;
                }
                
                somaDasBags.Associa(palavra, somaOcorrencias / numeroBags);
            }

            return somaDasBags;           
        }

        public double DistanciaAte(BagOfWords bag)
        {
            var palavras = Palavras.Concat(bag.Palavras).Distinct();

            double soma = 0;
            
            foreach(var palavra in palavras) 
            {
                int numOcorrencias1 = 0, numOcorrencias2 = 0;
                
                TentaObterOcorrencias(palavra, out numOcorrencias1);
                bag.TentaObterOcorrencias(palavra, out numOcorrencias2);

                soma += Math.Pow(numOcorrencias1 - numOcorrencias2, 2);
            }

            return Math.Sqrt(soma);
        }


        public double Modulo() 
        {
            double soma = 0;
            
            foreach(var palavra in Palavras) 
            {
                int numOcorrencias = 0;
                this.TentaObterOcorrencias(palavra, out numOcorrencias);
                soma += Math.Pow(numOcorrencias, 2);
            }

            return Math.Sqrt(soma);;
        }

        public void ImprimiNoConsole() 
        {
            if (!string.IsNullOrEmpty(Nome))
                Console.WriteLine(Nome);
            
            foreach (var entrada in _ocorrencias)
                Console.WriteLine(entrada);
        }        
    }
}