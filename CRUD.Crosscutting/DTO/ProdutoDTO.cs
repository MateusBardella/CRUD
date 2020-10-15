using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD.Crosscutting.DTO
{
    public class ProdutoDTO
    {
        public int? IdProduto { get; set; }

        public int? IdCategoria { get; set; }

        [DisplayName("Categoria")]
        public string NomeCategoria { get; set; }

        [DisplayName("Produto")]
        [Required(ErrorMessage = "Nome do Produto é obrigatório")]
        public string NomeProduto { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        public decimal Valor { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime? DataCadastro { get; set; }

        [DisplayName("Data Última Alteração")]
        public DateTime? DataAlteracao { get; set; }
        
    }
}
