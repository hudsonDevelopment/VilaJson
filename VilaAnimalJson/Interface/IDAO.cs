using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace VilaAnimalJson.Interface
{
    interface IDAO<T> : IDisposable
        where T: class,new()
    {
        T inserir(T model);
        void atualizar(T model);
        bool remover(T model);
        T localizarPorId(params Object[] Keys);
        Collection<T> ListarTudo();
    }
}
