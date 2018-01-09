﻿using Academy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class Repository<E> where E : EntityWithId
    {
        protected DbSet<E> Entities { get; set; }

        protected Entities DBase { get; set; }

        public Repository(DbSet<E> entities, Entities _dbase)
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
            Entities.Add(entity);
        }

        protected void BeforeDelete(E entity) { }

        public void Delete(E entity)
        {
            BeforeDelete(entity);
            Entities.Remove(entity);
        }

        public void Save()
        {
            DBase.SaveChanges();
        }
    }
}