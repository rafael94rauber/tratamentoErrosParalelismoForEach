using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tratamentoErrosParalelismoForEach;

namespace Servico.Jobs
{
    public static class Utilitarios
    {
        public enum TipoOperacao
        {
            AverbacaoCartao = 1,
            AverbacaoCreditoConsignado = 2,
            DesaverbacaoCartao = 3,
            DesaverbacaoCreditoConsignado = 4,
            metodoXPTO = 5,
            criarNOovo = 6

        }


        public static async Task TesteRauber(object teste, string valor, TipoOperacao tipoOperacao)
        {
            Console.WriteLine(tipoOperacao);
            Console.WriteLine(valor);
            Console.WriteLine(teste.ToString());
        }

        public static Task ExecutarGenerico<T>(this IEnumerable<T> ListaProcessamento, TipoOperacao tipoOperacao, int quantidadeParalelismo) where T : rauber
        {
            string objeto = "RoboEcoBem.AverbacaoCartaoJob.Execute";
            string mensagem = "Iniciou o job de Averbação cartão";
            int etapa = 1;
            bool erroExecucao = false;

            try
            {
                if (!(ListaProcessamento?.Any() ?? false))
                {
                    return Task.FromResult("OK");
                }

                _ = Parallel.ForEach(ListaProcessamento, new ParallelOptions() { MaxDegreeOfParallelism = quantidadeParalelismo },
                async (proposta) =>
                {
                    mensagem = null;
                    try
                    {
                        var task1 = Task.FromResult(mensagem);

                        Task task2 = null;
                        switch (tipoOperacao)
                        {
                            case TipoOperacao.AverbacaoCartao:
                                task2 = TesteRauber(proposta, proposta.nome, tipoOperacao);
                                break;
                            case TipoOperacao.AverbacaoCreditoConsignado:
                                task2 = TesteRauber(proposta, proposta.nome, tipoOperacao);
                                break;
                            case TipoOperacao.DesaverbacaoCartao:
                                task2 = TesteRauber(proposta, proposta.nome, tipoOperacao);
                                break;
                            case TipoOperacao.DesaverbacaoCreditoConsignado:
                                task2 = TesteRauber(proposta, proposta.nome, tipoOperacao);
                                break;
                            case TipoOperacao.metodoXPTO:
                                task2 = TesteRauber(proposta, proposta.nome, tipoOperacao);
                                break;
                            case TipoOperacao.criarNOovo:
                                task2 = TesteRauber(proposta, proposta.nome, tipoOperacao);
                                break;
                            default:
                                task2 = TesteRauber(proposta, proposta.nome, tipoOperacao);
                                break;
                        }


                        await Task.WhenAll(task1, task2);

                        mensagem = "Executou API Eco sem erro.";
                    }
                    catch (Exception ex)
                    {
                        mensagem = $"Erro ao executar API Eco: {ex}";
                        erroExecucao = true;
                    }
                }
                );
            }
            catch (Exception Ex)
            {
                mensagem = $"Erro: job averbação cartão: {Ex}";
                erroExecucao = true;
            }
            finally
            {
                mensagem = "finalizou job averbação cartão";
            }

            return Task.FromResult(mensagem);
        }
    }
}