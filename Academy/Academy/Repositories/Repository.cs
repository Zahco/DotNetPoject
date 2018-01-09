using Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class Repository<E> where E : EntityWithId
    {
        public IQueryable<E> Entities { get; set; }

        public Entities DBase { get; set; }

        public Repository(IQueryable<E> entities, Entities _dbase)
        {
            Entities = entities;
            DBase = _dbase;
        }

        public IEnumerable<E> All()
        {
            return Entities;
        }

        public E GetById(Guid id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        public void Add(E entity)
        {
            Entities.ToList().Add(entity);
        }

        public void Delete(E entity)
        {
            Entities.ToList().Remove(entity);
        }

        public void Save()
        {
            DBase.SaveChanges();
        }
    }
}