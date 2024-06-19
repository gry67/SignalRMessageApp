using SignalRDenemeler.BL.Abstract;
using SignalRDenemeler.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDenemeler.BL.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> repository;

        public GenericService(IGenericRepository<T> _repository)
        {
            repository = _repository;
        }

        public bool Create(T entity)
        {
            return repository.Create(entity);
        }

        public bool DeleteById(int id)
        {
            return repository.DeleteById(id);
        }

        public List<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Update(T entity)
        {
            return repository.Update(entity);
        }
    }
}
