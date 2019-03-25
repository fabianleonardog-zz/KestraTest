using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KestraTest.Contracts.Business
{
    public interface IBaseBusiness<T> where T : class
    {
        /// <summary>
        /// get all
        /// </summary>
        /// <returns>get all the recondrs of an entity</returns>
        List<T> GetAll();

        /// <summary>
        /// Get a single entity by a condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <returns>The entity result</returns>
        T Single(Expression<Func<T, bool>> predicate);

        T GetByIntId(int id);

        /// <summary>
        /// Create a single entity
        /// </summary>
        /// <param name="entity">entity</param>
        void Create(T entity);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">entity</param>
        void Update(T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);
    }
}
