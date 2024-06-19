using Microsoft.EntityFrameworkCore;
using SignalRDenemeler.DAL.Abstract;
using SignalRDenemeler.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDenemeler.DAL.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext _context)
        {
            context = _context;
            _dbSet = context.Set<T>();
        }

        public bool Create(T entity)
        {
            _dbSet.Add(entity);
            int sayac = context.SaveChanges();
            if (sayac > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteById(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            int sayac = context.SaveChanges();
            if (sayac > 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            int sayac = context.SaveChanges();

            if (sayac > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
