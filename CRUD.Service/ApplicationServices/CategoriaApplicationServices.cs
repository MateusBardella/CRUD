using CRUD.Crosscutting.DTO;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistance.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.Service.ApplicationServices
{
    public class CategoriaApplicationServices
    {
        private ProdutosUnitOfWork _uow;

        public CategoriaApplicationServices(ProdutosUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Categoria> GetListCategoria()
        {
            return _uow.Categoria.GetAll().ToList();
        }

        public Categoria GetCategoriaById(int id)
        {
            Categoria Categoria = _uow.Categoria.GetCategoriaById(id);

            if(Categoria == null)
                throw new Exception("Categoria não encontrada.");

            return Categoria;
        }

        public void Insert(CategoriaDTO categoriaDTO)
        {
            if (_uow.Categoria.ExistsCategoriaByNome(categoriaDTO.Nome))
                throw new Exception("Não é possível inserir, já existe a categoria de nome: " + categoriaDTO.Nome);

            Categoria Categoria = new Categoria();
            Categoria.Nome = categoriaDTO.Nome;
            Categoria.DataCadastro = DateTime.Now;

            _uow.Categoria.Add(Categoria);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            Categoria Categoria = _uow.Categoria.GetCategoriaById(id);

            if (Categoria == null)
                throw new Exception("Categoria não encontrada.");

            if(_uow.Produto.ExistsProdutoByIdCategoria(Categoria.IdCategoria))
                throw new Exception("Não é possível deletar esta categoria pois existem produtos relacionados.");

            _uow.Categoria.Delete(Categoria);
            _uow.Commit();
        }

        public void Update(CategoriaDTO categoriaDTO)
        {
            if (string.IsNullOrEmpty(categoriaDTO.Nome))
                throw new Exception("Nome não pode ser em branco");

            Categoria UpdateCategoria = _uow.Categoria.GetCategoriaById(categoriaDTO.IdCategoria.GetValueOrDefault());
            
            if (UpdateCategoria == null)
                throw new Exception("Categoria não encontrada.");

            if (categoriaDTO.Nome != UpdateCategoria.Nome && _uow.Categoria.ExistsCategoriaByNome(categoriaDTO.Nome))
                throw new Exception("Categoria:  " + categoriaDTO.Nome + " já existe");

            UpdateCategoria.Nome = categoriaDTO.Nome;
            UpdateCategoria.DataAlteracao = DateTime.Now;

            _uow.Commit();
        }
    }
}
