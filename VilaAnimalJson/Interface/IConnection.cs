using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VilaAnimalJson.Interface
{
    public interface IConnection : IDisposable
    {
        SqlConnection abrir();

        SqlConnection buscar();

        void fechar();
    }
}
