using Servico.Jobs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tratamentoErrosParalelismoForEach
{

    public class rauber
    {
       public string nome { get; set; }
    }
    public class JUCA: rauber
    {
        public string idade { get; set; }
        public string cpf { get; set; }
    }

    public class Pires: rauber
    {
        public string tamanho { get; set; }
        public string sobrenome { get; set; }

    }

    class Program
    {
        static async Task Main(string[] args)
        {


            var juca = new List<JUCA>();
            juca.Add(new JUCA() { nome = "rauber", cpf = "123", idade = "10" });
            juca.Add(new JUCA() { nome = "MOta", cpf = "321", idade = "10" });
            juca.Add(new JUCA() { nome = "Pires", cpf = "147", idade = "10" });


            var pires= new List<Pires>();
            pires.Add(new Pires() { nome = "rauber",  tamanho= "123", sobrenome = "10" });
            pires.Add(new Pires() { nome = "MOta", tamanho = "321", sobrenome = "10" });
            pires.Add(new Pires() { nome = "Pires", tamanho = "147", sobrenome = "10" });


            var task1 = Utilitarios.ExecutarGenerico(juca, Utilitarios.TipoOperacao.DesaverbacaoCartao, 5);
            var task2 = Utilitarios.ExecutarGenerico(pires, Utilitarios.TipoOperacao.AverbacaoCreditoConsignado, 1);

            await Task.WhenAll(task1, task2);

            //string x = "dsds";
            //string y = x;

            //string? teste = null;

            //int[] lista = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };



            //Teste t = new Teste();
            //t.Testar(lista);

            //string[] ss = null;
            //List<string> s = new List<string>();
            //s.Add("");

            //var xxx = s?.Any() ?? false;

        }

    }


    public class Teste
    {
        public Task Testar(int[] lista)
        {
            var exceptions = new ConcurrentQueue<Exception>();

            _ = Parallel.ForEach(lista, new ParallelOptions()
            { MaxDegreeOfParallelism = 2 },
              async (proposta) =>
              {
                  try
                  {
                      throw new Exception("dsadsadsa");
                  }
                  catch (Exception ex)
                  {
                      exceptions.Enqueue(ex);
                  }
              });

            return Task.FromResult("OK");
        }
    }
}
