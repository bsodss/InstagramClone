using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstagramClone.DAL.Entities;

namespace InstagramClone.DAL.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        public IQueryable<User> FindAllWithDetails();
        public User GetByIdWithDetails(string id);

    } 
}
