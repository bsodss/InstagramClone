using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.DAL.Interfaces
{
    public interface IUnitOfWork
    {

        Task<int> SaveAsync();
    }
}
