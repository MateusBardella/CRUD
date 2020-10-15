using CRUD.Domain.Entities;
using CRUD.Infrastructure.GenericPersistence.GenericRepository;
using CRUD.Infrastructure.Model;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Infrastructure.Persistance.Repository
{
    public class ProdutoRepository : GenericRepository<Produto, AppDataContext>
    {
        public ProdutoRepository(AppDataContext context) : base(context) { }

        public Produto GetProdutoById(int id)
        {
            return _context.Produto.FirstOrDefault(x => x.IdProduto == id);
        }

        public bool ExistsProdutoByNome(string nome)
        {
            return _context.Produto.Any(x => nome.Contains(x.Nome));
        }

        public bool ExistsProdutoByIdCategoria(int id)
        {
            return _context.Produto.Any(x => x.IdCategoria == id);
        }
    }
}
