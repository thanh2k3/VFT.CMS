using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        Task<T> GetById(int id);
        List<T> Add(T entity);
        List<T> Edit(T entity);
        List<T> Delete(T entity);
        List<T> Details(T entity);
    }
}
