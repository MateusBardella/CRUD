using CRUD.Crosscutting.DTO;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistance.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.Service.ApplicationServices
{
    public class ProdutoApplicationServices
    {
        private ProdutosUnitOfWork _uow;

        public ProdutoApplicationServices(ProdutosUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<ProdutoDTO> GetListProduto()
        {
            return GetQueryProduto().ToList();
        }

        private IQueryable<ProdutoDTO> GetQueryProduto()
        {
            var QueryProduto = _uow.Produto.GetAllReadOnly();
            var QueryCategoria = _uow.Categoria.GetAllReadOnly();

            var Query = (from Produto in QueryProduto
                         join Categoria in QueryCategoria on Produto.IdCategoria equals Categoria.IdCategoria
                         orderby Produto.Nome
                         select new ProdutoDTO
                         {
                             IdProduto = Produto.IdProduto,
                             IdCategoria = Produto.IdCategoria,
                             NomeCategoria = Categoria.Nome,
                             NomeProduto = Produto.Nome,
                             Valor = Produto.Valor,
                             DataCadastro = Produto.DataCadastro,
                             DataAlteracao = Produto.DataAlteracao,
                         });

            return Query;
        }

        public ProdutoDTO GetProdutoById(int id)
        {
            ProdutoDTO Produto = GetQueryProduto().Where(x => x.IdProduto == id).FirstOrDefault();

            if(Produto == null)
                throw new Exception("Produto não encontrado.");

            return Produto;
        }

        public void Insert(ProdutoDTO produtoDTO)
        {
            if (_uow.Produto.ExistsProdutoByNome(produtoDTO.NomeProduto))
                throw new Exception("Não é possível inserir, já existe o produto de nome: " + produtoDTO.NomeProduto);

            Produto Produto = new Produto();
            Produto.Nome = produtoDTO.NomeProduto;
            Produto.IdCategoria = produtoDTO.IdCategoria.GetValueOrDefault();
            Produto.Valor = produtoDTO.Valor;
            Produto.DataCadastro = DateTime.Now;

            _uow.Produto.Add(Produto);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            Produto Produto = _uow.Produto.GetProdutoById(id);

            if (Produto == null)
                throw new Exception("Produto não encontrado.");

            _uow.Produto.Delete(Produto);
            _uow.Commit();
        }

        public void Update(ProdutoDTO produtoDTO)
        {
            Produto UpdateProduto = _uow.Produto.GetProdutoById(produtoDTO.IdProduto.GetValueOrDefault());

            if (UpdateProduto == null)
                throw new Exception("Produto não encontrado.");

            UpdateProduto.Nome = produtoDTO.NomeProduto;
            UpdateProduto.Valor = produtoDTO.Valor;
            UpdateProduto.DataAlteracao = DateTime.Now;

            _uow.Commit();
        }
    }
}
