using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;

namespace InstagramClone.DAL.Interfaces
{
    public interface IUnitOfWork : IGenericRepositoryFactory
    {
        Task<int> SaveAsync();
    }
}
