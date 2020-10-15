using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRUD.Domain.Entities
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        [DisplayName("Produto")]
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal Valor { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Data Última Alteração")]
        public DateTime? DataAlteracao { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
