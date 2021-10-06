using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;

namespace InstagramClone.BLL.Interfaces
{
    public interface IBaseService<TModel>
    {
        IEnumerable<TModel> GetAll();

        Task<TModel> GetByIdAsync(string id);

        Task AddAsync(TModel model);

        Task UpdateAsync(TModel model);

        Task DeleteByIdAsync(string modelId);
    }

}

