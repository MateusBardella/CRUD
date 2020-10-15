using CRUD.Domain.Entities;
using CRUD.Infrastructure.GenericPersistence.GenericRepository;
using CRUD.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.Infrastructure.Persistance.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria, AppDataContext>
    {
        public CategoriaRepository(AppDataContext context) : base(context) { }

        public Categoria GetCategoriaById(int id)
        {
            return _context.Categoria.FirstOrDefault(x => x.IdCategoria == id);
        }

        public bool ExistsCategoriaByNome(string nome)
        {
            return _context.Categoria.Any(x => x.Nome.Trim() ==  nome.Trim());
        }
    }
}
