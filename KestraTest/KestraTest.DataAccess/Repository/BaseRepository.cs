using KestraTest.Contracts.DataAccess;
using KestraTest.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KestraTest.DataAccess.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public KestraStudentContext context;
        /// <summary>
        /// get all
        /// </summary>
        /// <returns>get all the recondrs of an entity</returns>
        public List<T> GetAll()
        {
            return (List<T>)context.Set<T>().AsNoTracking().DefaultIfEmpty().ToList();
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">entity</param>
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        /// <summary>
        /// Get a single entity by a condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <returns>The entity result</returns>
        public T Single(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }
    }
}
