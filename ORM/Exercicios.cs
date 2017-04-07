using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Maps;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace ORM
{
    public class Exercicios
    {
        //imcompleto
        public static void exe51(ISession session)
        {
            //51-Altere todos os registros que possuam Data de saída  = 06/01/1993, para Data de Saída = 06 / 01 / 1993
            var cli = session.Query<T_Cliente>().Where(x => x.pais.codigo == "BR");
            foreach (var item in cli)
            {
                Console.WriteLine("Cliente: " + item.nome);
            }
        }
        public static void exe105(ISession session)
        {
            //105-Para as aeronaves do tipo jato e que são de companhias de países com mais 
            //de 1 milhão de habitantes, listar o nome do equipamento e o nome de sua companhia.
            var cli = session.Query<T_Cliente>().Where(x => x.pais.codigo == "BR");
            foreach (var item in cli)
            {
                Console.WriteLine("Cliente: " + item.nome);
            }
        }

        //concluido, talvez com sucesso

        public static void exe64(ISession session)
        {
            //64-Selecione os clientes que possuem reserva e o número de reservas de cada cliente
            var qcli = session.Query<T_Cliente>()
                .Where(x => x.reservas.Count() > 0)
                .Select(c => new { c.nome, c.reservas.Count } );
            var cli = qcli.ToList();
            foreach (var item in cli)
            {
                Console.WriteLine("Cliente {0}, Reservas: {1}", item.nome, item.Count);
            }
        }
        public static void exe6(ISession session)
        {
            //6-Listar os nomes dos clientes brasileiros
            var qcli = session.Query<T_Cliente>()
                .Where(x => x.pais.codigo=="BR")
                .Select(c => new { c.nome });
            var cli = qcli.ToList();
            Console.WriteLine("Clientes Brasileiros:");
            foreach (var item in cli)
            {
                Console.WriteLine("Cliente: " + item.nome);
            }
        }
        public static void exe117(ISession session)
        {
            //117-Quais são os clientes que nunca fizeram reserva?
            var qcli = session.Query<T_Cliente>()
                .Where(x => x.reservas == null)
                .Select(c => new { c.nome });
            var cli = qcli.ToList();
            Console.WriteLine("Clientes que nunca fizeram reserva:");
            foreach (var item in cli)
            {
                Console.WriteLine("Cliente: " + item.nome);
            }
        }
        public static void exe15(ISession session)
        {
            //15-Listar os números, a data/hora de saída dos vôos que partam 
            //antes das 6 da manhã e não atendem as rotas 001, 002, 003.
            var qvoo = session.Query<T_Voo>()
                .Where(x => x.hrSaida.Hour < 06 
                        && x.rota.numero != 001 
                        && x.rota.numero != 002 
                        && x.rota.numero != 003)
                .Select(v => new { v.numero, v.dataSaida, v.hrSaida });
            var voos = qvoo.ToList();
            foreach (var item in voos)
            {
                Console.WriteLine("Voo:{0}, Data saida:{1} {2}", item.numero, item.dataSaida.ToShortDateString(), item.hrSaida.ToShortTimeString() );
            }
        }


        public static void exe90(ISession session)
        {
            //90-Calcular o valor médio do preço dos bilhetes das rotas que partem do 
            //aeroporto JFK em New York.
            var qrota = session.Query<T_Rota>()
                .Where(x => x.origem.codigo=="JFK")
                .Select(r => new {r.valorbilhete}).Average(r => r.valorbilhete);
            Console.WriteLine("Média do preço do bilhete " + qrota.ToString());
            //var voos =
            //foreach (var item in voos)
            //{
            //    Console.WriteLine("Voo:{0}, Data saida:{1} {2}", item.numero, item.dataSaida.ToShortDateString(), item.hrSaida.ToShortTimeString());
            //}
        }

        //116-Relacionar os nomes dos clientes que estão com reservas para os vôos onde ninguém teve desconto.
        //11-Listar os códigos dos equipamentos com a quantidade de motores desconhecida.
        //26-Listar o valor do bilhete mais barato do vôo que sai do GALEÃO (“GIG”).
        //22-Listar o nome, a data de nascimento e a idade de todos os clientes brasileiros(BR), japoneses(JA) ou franceses(FR).
        //91-Calcular a data média dos vôos programados para a rota 101.
        //82-Listar o nome dos equipamentos não "jato" com sua capacidade de transporte de passageiros acrescida de 10 passageiros.
        //17-Listar o nome do cliente e o código do respectivo responsável para os que nasceram em data desconhecida.

    }
}
