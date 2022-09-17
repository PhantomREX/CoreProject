using CoreProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoreProject.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        Context c = new Context();

        public List<T> GenericList()
        {
            return c.Set<T>().ToList();
        }
        public void GenericAdd(T parameter)
        {
            c.Set<T>().Add(parameter);
            c.SaveChanges();
        }
        public void GenericDelete(T parameter)
        {
            c.Set<T>().Remove(parameter);
            c.SaveChanges();

        }

        public T GenericGet(int id)
        {

            return c.Set<T>().Find(id);

        }

        public void GenericUpdate(T parameter)

        {
            c.Set<T>().Update(parameter);
            c.SaveChanges();

        }

        public List<T> GenericList(string p)
        {
            return c.Set<T>().Include(p).ToList();

        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {

            return c.Set<T>().Where(filter).ToList();
        }
    }
}
    