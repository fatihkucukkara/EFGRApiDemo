using EFGRApiDemo.Dal.Base.Interfaces;
using EFGRApiDemo.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EFGRApiDemo.Dal.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;
        public GenericRepository(SchoolContext context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception("");
            }
        }

        //public void Delete(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //    _context.SaveChanges();
        //}
        public T GetById(int Id)
        {
            return Entities.Find(Id);            
        }
        public int Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            Entities.Add(entity);
            //_context.Set<T>().Add(entity);

            var id =_context.SaveChanges();

            return id;
        }
        public void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException();

            Entities.AddRange(entities);
            _context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            Entities.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> Table => Entities;

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }
    }
}
