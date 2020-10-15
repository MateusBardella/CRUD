using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Infrastructure.GenericPersistence.GenericUnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
