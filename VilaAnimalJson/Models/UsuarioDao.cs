using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VilaAnimalJson.Interface;
using VilaAnimalJson.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections;

namespace VilaAnimalJson.Models
{
    public class UsuarioDao : IDAO<Usuario>,IDisposable
    {
        private IConnection conexao;

        public UsuarioDao(IConnection conexao)
        {
            this.conexao = conexao;
        }

        public Usuario inserir(Usuario model)
        {
            using (SqlCommand comando = conexao.buscar().CreateCommand())
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = "insert into Usuario (nome) values (@nome)";
                comando.Parameters.Add("@nome", SqlDbType.Decimal).Value = model.Nome;
                model.id = int.Parse(comando.ExecuteScalar().ToString());
            }
            return model;
        }
        public void atualizar(Usuario model)
        {
            using (SqlCommand comando = conexao.buscar().CreateCommand())
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = "update Usuario set nome = @nome where id=@id";

                comando.Parameters.Add("@nome", SqlDbType.Text).Value = model.Nome;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = model.id;
                comando.ExecuteNonQuery();
            }
        }
        public bool remover(Usuario model)
        {
            using (SqlCommand comando = conexao.buscar().CreateCommand())
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = "delete from Usuario where id=@id";

                if(comando.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public Usuario localizarPorId(params object[] Keys)
        {
            Usuario usuario = null;
            using (SqlCommand comando = conexao.buscar().CreateCommand())
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Select * from Usuario where id=@id";
                comando.Parameters.Add("@id", SqlDbType.Int).Value = Keys[0];

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        usuario = new Usuario();
                        reader.Read();
                        usuario.id = reader.GetInt32(0);
                        usuario.Nome = reader.GetString(1);
                    }
                }
            }
            return usuario;
        }
        public Collection<Usuario> ListarTudo()
        {
            Collection<Usuario> colecao = new Collection<Usuario>();

            using (SqlCommand comando = conexao.buscar().CreateCommand())
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from Usuario order by nome";

                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);

                    foreach(DataRow row in tabela.Rows)
                    {
                        Usuario usuario = new Usuario
                        {
                            id = int.Parse(row["id"].ToString()),
                            Nome = row["nome"].ToString()
                        };
                        colecao.Add(usuario);
                    }
                }
            }
            return colecao;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}