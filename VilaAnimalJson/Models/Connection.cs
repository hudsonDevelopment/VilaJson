using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VilaAnimalJson.Interface;

namespace VilaAnimalJson.Models
{
    public class Connection : IConnection,IDisposable
    {
        private SqlConnection conexao;
        private string dataSource = "Data Source=(localdb)/MSSQLLocalDB;Initial Catalog = C:/USERS/ADMIN/SOURCE/REPOS/VILAANIMALJSON/VILAANIMALJSON/APP_DATA/BASEVILAANIMAL.MDF; Connect Timeout = 30; TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Connection()
        {
            conexao = new SqlConnection(dataSource);
        }
        public SqlConnection abrir()
        {
            if(conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }
            return conexao;
        }
        public SqlConnection buscar()
        {
            return this.abrir();
        }
        public void fechar()
        {
            if(conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        public void Dispose()
        {
            this.fechar();
            GC.SuppressFinalize(this);
        }
        /*private SqlConnection conexao;

        private SqlConnection criaConexao()
        {
            this.conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString);
            return conexao;
        }*/
    }
}