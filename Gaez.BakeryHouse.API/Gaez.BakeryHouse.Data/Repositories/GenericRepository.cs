using Gaez.BakeryHouse.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private GaezDbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new GaezDbContext();
            table = _context.Set<T>();
        }
        public GenericRepository(GaezDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public T GetById(int clientId, int productCode)
        {
            return table.Find(clientId, productCode);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Delete(int clientId, int productCode)
        {
            T existing = table.Find(clientId, productCode);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
