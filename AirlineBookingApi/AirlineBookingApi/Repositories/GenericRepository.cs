using AirlineBookingApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirlineBookingApi.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        public AirlineBookingContext Db { get; set; }

        public GenericRepository(AirlineBookingContext context)
        {
            Db = context;
        }

        public virtual bool Add(T entity)
        {
            try
            {
                Db.Set<T>().Add(entity);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                Db.Set<T>().Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Edit(T entity)
        {
            try
            {
                Db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual IEnumerable<T> GetList()
        {
            return Db.Set<T>().ToList();
        }

        public virtual T GetById(string id)
        {
            return Db.Set<T>().Find(id);
        }
    }
}