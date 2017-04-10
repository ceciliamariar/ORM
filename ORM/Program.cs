using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using ORM.Maps;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace ORM
{
    class Program
    {
        static void consulta()
        {
            //Lambda Expression
            Func<int, int, int> LambdaEx = (x, y) => x * y;

            int z = LambdaEx(2, 3);

            //Expression Tree Type
            Expression<Func<int, int, int>> ExpressionTree = (x, y) => x * y;

            // 'compilando' a função
            var Exp = ExpressionTree.Compile();
            //agora ela pode ser usada como função
            int j = Exp(4, 5);


            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var reservas = session.Query<T_Reserva>().ToList();
                foreach (var item in reservas)
                {
                    Console.WriteLine("Reserva voo: {0},{1},{2}", item.voo.numero, item.voo.dataSaida, item.voo.hrSaida);
                    Console.WriteLine("Reserva Cliente: {0},{1}", item.cliente.codigo, item.cliente.nome);
                    Console.WriteLine("Reserva voo: {0}", item.desconto);
                }
                var clientes = session.Query<T_Cliente>().ToList();
                foreach (var item in clientes)
                {
                    Console.WriteLine("Cliente id: {0}", item.codigo);
                    Console.WriteLine("Cliente nome: {0}", item.nome);
                    Console.WriteLine("Cliente Data de Nascimento: {0}", item.dtnascimento);
                }
                Console.WriteLine("\n\nFim da consulta!");
                Console.ReadLine();
            }
        }
        static void testeGrupJoin()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var clientesM = session.Query<T_Cliente>().ToList();
                var reservasM = session.Query<T_Reserva>().ToList();
                var query = clientesM.GroupJoin
                    (reservasM,
                    cli => cli.codigo,
                    res => res.cliente.codigo,
                    (cliente, reservas) => new { Nome = cliente.nome, Reserva = reservas });
                foreach (var item in query)
                {
                    Console.WriteLine("Cliente: " + item.Nome);
                    foreach (var reserva in item.Reserva)
                    {
                        Console.WriteLine(reserva.voo.dataSaida.ToShortDateString());
                    }
                }
                Console.ReadLine();
                var pesquisa = clientesM.Where(x => x.reservas.Count > 0);
                foreach (var item in pesquisa)
                {
                    Console.WriteLine(item.nome);
                    foreach (var reserva in item.reservas)
                    {
                        Console.WriteLine(reserva.voo.dataSaida.ToShortDateString());
                    }
                }
            }
        }
        static void testeJoin()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var clientesM = session.Query<T_Cliente>();
                var reservasM = session.Query<T_Reserva>();
                var query = clientesM.Join
                    (reservasM,
                    cli => cli.codigo,
                    res => res.cliente.codigo,
                    (cliente, reservas) => new { Nome = cliente.nome, Reserva = reservas });
                int count = 0;
                foreach (var item in query)
                {
                    count++;
                    Console.WriteLine("\nCliente: " + item.Nome);

                    Console.WriteLine("Reserva: " + item.Reserva.voo.dataSaida.ToShortDateString());
                }
                Console.WriteLine("\n\n\nReservas: " + count);
                Console.ReadLine();

            }
        }
        static void Main(string[] args)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                Exercicios.exe82(session);
            }
            Console.ReadLine();
        }
    }

}


