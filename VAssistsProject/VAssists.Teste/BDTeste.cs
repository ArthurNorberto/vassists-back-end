using MySql.Data.MySqlClient;
using NUnit.Framework;
using System.Data;

namespace VAssists.Teste
{
    [TestFixture]
    public class BDTeste
    {
        [Test]
        public void TestMethod1()
        {
            MySqlConnection bdConn; //MySQL
            //Define string de conexão
            bdConn = new MySqlConnection("Server=localhost;Database=producao;Uid=root;Pwd=root;");

            Assert.DoesNotThrow(() => bdConn.Open());

            Assert.AreEqual(ConnectionState.Open, bdConn.State);
        }
    }
}