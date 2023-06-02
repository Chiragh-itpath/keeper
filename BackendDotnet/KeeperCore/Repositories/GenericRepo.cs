using KeeperCore.Repositories.Interfaces;
using KeeperDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperCore.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DbKeeperContext _keeper;

        public GenericRepo(DbKeeperContext keeper)
        {
            _keeper = keeper;
        }

        public List<T> GetAll()
        {
            return _keeper.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _keeper.Set<T>().Find(id) ?? throw new Exception("No such record exists");
        }

        public int Insert(T item)
        {
            _keeper.Set<T>().Add(item);
            return _keeper.SaveChanges();
        }

        public int Update(T item)
        {
            _keeper.Set<T>().Update(item);
            return _keeper.SaveChanges();
        }
        public int Delete(T item)
        {
            _keeper.Set<T>().Remove(item);
            return _keeper.SaveChanges();
        }
    }
}
