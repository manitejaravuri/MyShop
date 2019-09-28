using Myshop.core.contracts;
using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.DataAccess.SQL
{
    public class SQL_Repositary<T> : IRepositary<T> where T : BaseEntity
    {

        internal Datacontext context;

        internal DbSet<T> dbset;

        public SQL_Repositary(Datacontext context)
        {
            this.context = context;

            this.dbset = context.Set<T>();
        }
        IQueryable<T> IRepositary<T>.collection()
        {
            return dbset;
        }

        void IRepositary<T>.commit()
        {
            context.SaveChanges();
        }

        void IRepositary<T>.Delete(string Id)
        {
            var t = Find(Id);

            if (context.Entry(t).State == EntityState.Detached) 
            dbset.Attach(t);

            dbset.Remove(t);
        }

        private object Find(string id)
        {
            throw new NotImplementedException();
        }

        T IRepositary<T>.Find(string Id)
        {
            return dbset.Find(Id);
        }

        void IRepositary<T>.Insert(T t)
        {
            dbset.Add(t);
        }

        void IRepositary<T>.Update(T t)
        {
            dbset.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
