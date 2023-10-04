using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_GLOBAL5.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome da Marca")]
        public string Marca { get; set; }

        public int Nacional { get; set; }

        public Boolean Ativo { get; set; }
    }
}
