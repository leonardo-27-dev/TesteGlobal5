using CRUD_GLOBA5.Data;
using CRUD_GLOBAL5.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_GLOBAL5.Repositorio
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public MarcaRepositorio(BancoContext BancoContext) {
            _bancoContext = BancoContext;
        }

        public ConsultaModel Adicionar(ConsultaModel marca)
        {
            // Insere Dados no Banco de Dados
            _bancoContext.Marcas.Add(marca);
            _bancoContext.SaveChanges();
            return marca;
        }

        public ConsultaModel Atualizar(ConsultaModel marca)
        {
            ConsultaModel marcaDB = ListarPorId(marca.Id);

            if (marcaDB == null) throw new System.Exception("Não existe registro para este Id");

            marcaDB.Ativo = marca.Ativo;
            marcaDB.Nacional = marca.Nacional;
            marcaDB.Marca = marca.Marca;

            _bancoContext.Marcas.Update(marcaDB);
            _bancoContext.SaveChanges();

            return marcaDB;
        }

        public List<ConsultaModel> BuscarTodos()
        {
            return _bancoContext.Marcas.ToList();
        }

        public ConsultaModel ListarPorId(int id)
        {
            return _bancoContext.Marcas.FirstOrDefault(x => x.Id == id);
        }
    }
}
