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
            //51-Altere todos os registros que possuam Data de saída  = 06/01/1993, 
            // para Data de Saída = 06 / 01 / 1993
            session.Transaction.Begin();
            var voo = session.Query<T_Voo>().Where(v => v.dataSaida == new DateTime(1993, 01, 06));
            var t = voo.ToList();
            foreach (var item in t)
            {
                item.dataSaida = item.dataSaida.AddDays(1);//new DateTime(1993, 01, 07);
                session.Update(item);
                Console.WriteLine("Ok " + item.numero);
            }
            session.Transaction.Commit();
            session.Flush();
        }


        public static void exe116(ISession session)
        {
            //116-Relacionar os nomes dos clientes que estão com reservas para os vôos onde
            // ninguém teve desconto.
            var semdesconto = session.Query<T_Voo>()
                .Where(x => x.reservas.Where(c => c.desconto > 0) != null)
                .Select(a => a.reservas.Select(q => q.cliente.nome));

        }

        /****/
        public static void exe22(ISession session)
        {
            //22-Listar o nome, a data de nascimento e a idade de todos os clientes brasileiros(BR), 
            //japoneses(JA) ou franceses(FR).
            var qcli = session.Query<T_Cliente>()
                .Where(x => x.pais.codigo == "BR"
                        || x.pais.codigo == "JA"
                        || x.pais.codigo == "FR");
            //.Select(c => new { c.nome, c.dtnascimento, c.pais });
            var cli = qcli.ToList();
            Console.WriteLine("Clientes:");
            foreach (var item in cli)
            {
                Console.WriteLine("Cliente: {0}, \nNascimento:{1} \nIdade: {2}\nNatural de {3}\n\n", item.nome, item.dtnascimento.ToShortDateString(), Convert.ToUInt16(DateTime.Now.Subtract(item.dtnascimento).TotalDays / 365), item.pais.nome);
            }
        }
        /******/


        //91-Calcular a data média dos vôos programados para a rota 101.
        public static void exe91(ISession session) { }



        //concluido, talvez com sucesso

        public static void exe64(ISession session)
        {
            //64-Selecione os clientes que possuem reserva e o número de reservas de cada cliente
            var qcli = session.Query<T_Cliente>()
                .Where(x => x.reservas.Count() > 0)
                .Select(c => new { c.nome, c.reservas.Count });
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
                .Where(x => x.pais.codigo == "BR")
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
                Console.WriteLine("Voo:{0}, Data saida:{1} {2}", item.numero, item.dataSaida.ToShortDateString(), item.hrSaida.ToShortTimeString());
            }
        }
        public static void exe90(ISession session)
        {
            //90-Calcular o valor médio do preço dos bilhetes das rotas que partem do 
            //aeroporto JFK em New York.
            var qrota = session.Query<T_Rota>()
                .Where(x => x.origem.codigo == "JFK")
                .Select(r => new { r.valorbilhete }).Average(a => a.valorbilhete);
            Console.WriteLine("Média do preço do bilhete para JFK: R$ " + qrota.ToString());

        }
        public static void exe11(ISession session)
        {
            //11-Listar os códigos dos equipamentos com a quantidade de motores desconhecida.
            var qeqp = session.Query<T_Equipamento>()
                .Where(x => x.qtdmotor == null);
            var eqp = qeqp.ToList();
            foreach (var item in eqp)
            {
                Console.WriteLine("Equipamento: " + item.nome);

            }
        }
        public static void exe26(ISession session)
        {

            //26-Listar o valor do bilhete mais barato do vôo que sai do GALEÃO (“GIG”).
            var qrota = session.Query<T_Rota>()
                .Where(x => x.origem.codigo == "GIG")
                .Select(r => new { r.valorbilhete }).Min(a => a.valorbilhete);
            Console.WriteLine("Bilhete mais barato para Galeão custa: R$ " + qrota.ToString());

        }
        public static void exe17(ISession session)
        {

            //17-Listar o nome do cliente e o código do respectivo responsável 
            //para os que nasceram em data desconhecida.
            var qcli = session.Query<T_Cliente>()
                .Where(x => x.dtnascimento == null)
                .Select(r => new { r.nome, r.responsavel.codigo });
            var cli = qcli.ToList();
            foreach (var item in cli)
            {
                Console.WriteLine("Cliente {0}, Cod. Responsavel {1}", item.nome, item.codigo == null ? "Não existe responsavel" : item.codigo);
            }

        }
        public static void exe82(ISession session)
        {
            //82-Listar o nome dos equipamentos não "jato" com sua capacidade de 
            //transporte de passageiros acrescida de 10 passageiros.
            var qeqp = session.Query<T_Equipamento>()
                .Where(e => !e.tipo.Like("%jato%"))
                .Select(e => new { e.nome, e.qtdpassag });
            var eqp = qeqp.ToList();
            foreach (var item in eqp)
            {
                Console.WriteLine("Equipamento:{0} Qtd Passageiro+10: {1},  {2}", item.nome, item.qtdpassag + 10);
            }
        }
        public static void exe105(ISession session)
        {
            //105-Para as aeronaves do tipo jato e que são de companhias de países com mais 
            //de 1 milhão de habitantes, listar o nome do equipamento e o nome de sua companhia.
            var qaeron = session.Query<T_Aeronave>()
                .Where(x => x.ciaarea.pais.populacao > 1000000
                && x.equipamento.tipo.Like("%jato%"))
                .Select(a => new { eqp = a.equipamento.nome, cia = a.ciaarea.nome });
            var aeron = qaeron.ToList();
            foreach (var item in aeron)
            {
                Console.WriteLine("Aeronave\nEquipamento:{0}, Cia Aerea: {1} ", item.eqp, item.cia);
            }
        }

    }
}
