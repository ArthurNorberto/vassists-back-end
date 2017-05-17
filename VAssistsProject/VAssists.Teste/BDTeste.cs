using Domínio.Modelo;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;
using System;
using System.Data;
using System.Linq;
using VAssistsInfra.Conexão;

namespace VAssists.Teste
{
    [TestFixture]
    public class BDTeste
    {
        [Test]
        public void TesteDeConexao()
        {
            MySqlConnection bdConn; //MySQL
            //Define string de conexão
            bdConn = new MySqlConnection("Server=localhost;Database=producao;Uid=root;Pwd=root;");

            Assert.DoesNotThrow(() => bdConn.Open());

            Assert.AreEqual(ConnectionState.Open, bdConn.State);
        }

        [Test]
        public void TesteDeConexaoNHibernate()
        {
            Assert.DoesNotThrow(() => SessionFactory.OpenSession());
        }

        [Test]
        public void TesteSelect()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var query = session.CreateSQLQuery("SELECT COUNT(1) QTD FROM USUARIO");
                var resultado = query.UniqueResult();

                Assert.AreEqual(0, Convert.ToInt32(resultado));
            }
        }

        [Test]
        public void TesteConnectionString()
        {
            Assert.AreEqual("Server=localhost;Database=producao;Uid=root;Pwd=root;", SessionFactory.connectionString);
        }

        [Test]
        public void TesteDeInsert()
        {
            int atual = 0;
            int resultado = 0;
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        atual = session.Query<Usuario>().Count();

                        
                        var usuario = new Usuario
                        {
                            NomeUsuario = "Arthur",
                            Email = "arthur@teste.com.br"
                        };

                        session.Save(usuario);

                        transaction.Commit();
                        session.Flush();

                        resultado = session.Query<Usuario>().Count();                        
                    }
                    catch
                    {
                        transaction.Rollback();
                        session.Flush();
                        throw;
                    }

                    Assert.AreEqual(atual + 1, resultado);
                }
            }
        }
    }
}