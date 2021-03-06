using System;
using System.Collections.Generic;
using System.Text;
using InstagramClone.DAL.Entities;

namespace InstagramClone.DAL.Interfaces
{
    public interface IGenericRepositoryFactory
    {
        IRepository<T> GetGenericRepository<T>() where T : BaseEntity;
    }
}
