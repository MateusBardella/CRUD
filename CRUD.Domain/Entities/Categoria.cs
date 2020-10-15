using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [DisplayName("Categoria")]
        public string Nome { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Data Última Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}
