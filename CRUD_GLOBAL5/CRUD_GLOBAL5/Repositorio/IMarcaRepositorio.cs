using CRUD_GLOBAL5.Models;
using System.Collections.Generic;

namespace CRUD_GLOBAL5.Repositorio
{
    public interface IMarcaRepositorio
    {
        ConsultaModel ListarPorId(int id);

        List<ConsultaModel> BuscarTodos();

        ConsultaModel Adicionar(ConsultaModel marca);

        ConsultaModel Atualizar(ConsultaModel marca);
    }
}
