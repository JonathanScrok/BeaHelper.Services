using BeaHelper.BLL.BD;
using System;
using System.Diagnostics;

namespace BeaHelper.Service.VerificaEventoRecorrente
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Serviço iniciado");

            ScheduleSomething();

            Console.WriteLine("Aguardou 4 segundos e finalizou ...");

            void ScheduleSomething()
            {

                var DataParaRodar = DateTime.Today + TimeSpan.FromHours(22);
                var Proximoconsole = DateTime.Now;

                while (true)
                {
                    if (DataParaRodar == DateTime.Now)
                    {
                        VerificaEventosRecorrentes();
                    }
                }
            }
        }

        static void VerificaEventosRecorrentes()
        {

            var IdsVagas = Vaga_P2.EVENTOS_RECORRENTES();
            

            if (IdsVagas != null && IdsVagas.Count > 0)
            {
                foreach (var vaga in IdsVagas)
                {
                    Vaga_P1 vagaAtualizar = new Vaga_P1(vaga.Id_Vaga);
                    vagaAtualizar.CompleteObject();
                    DateTime dataEvento = vagaAtualizar.DataEvento.Value;
                    DateTime dataSeguinte = dataEvento.AddMonths(1);

                    vagaAtualizar.DataEvento = dataSeguinte;
                    vagaAtualizar.Categoria = vagaAtualizar.Categoria;
                    vagaAtualizar.CidadeEstado = vagaAtualizar.CidadeEstado;
                    vagaAtualizar.DataPublicacao = vagaAtualizar.DataPublicacao;
                    vagaAtualizar.Descricao = vagaAtualizar.Descricao;
                    vagaAtualizar.EventoRecorrente = vagaAtualizar.EventoRecorrente;
                    vagaAtualizar.IdUsuarioAdm = vagaAtualizar.IdUsuarioAdm;
                    vagaAtualizar.Titulo = vagaAtualizar.Titulo;
                    vagaAtualizar.Save();

                }
            }

        }
    }
}
