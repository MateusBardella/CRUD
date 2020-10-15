using CRUD.Domain.Entities;
using CRUD.Infrastructure.GenericPersistence.GenericUnitOfWork;
using CRUD.Infrastructure.Model;
using CRUD.Infrastructure.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Infrastructure.Persistance.UnitOfWork
{
    public class ProdutosUnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _context;

        public ProdutosUnitOfWork(AppDataContext context) 
        {
            _context = context;
            Categoria = new CategoriaRepository(_context);
            Produto = new ProdutoRepository(_context);
        } 
        
        public CategoriaRepository Categoria { get; private set; }
        public ProdutoRepository Produto { get; private set; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //
        }
    }
}
