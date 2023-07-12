//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VFT.CMS.Repository.Data;

//namespace VFT.CMS.Repository.GenericRepository
//{
//    public class GenericRepository<T> : IGenericRepository<T> where T : class
//    {
//        private readonly AppDBContext _context;

//        public GenericRepository(AppDBContext context)
//        {
//            _context = context;
//        }

//        public async Task<T> Create(T entity)
//        {
//            await _context.AddAsync(entity);
//            await _context.SaveChangesAsync();
//            return entity;
//        }

//        public async Task Delete(T entity)
//        {
//            _context.Set<T>().Remove(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<IEnumerable<T>> GetAll()
//        {
//            return await _context.Set<T>().ToListAsync();
//        }

//        public async Task<T> GetById(int id)
//        {
//            return await _context.Set<T>().FindAsync(id);
//        }

//        public async Task Update(T entity)
//        {
//            _context.Entry(entity).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//        }
//    }
//}
