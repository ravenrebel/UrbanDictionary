using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace UrbanDictionary.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// Contains basic queries for <typeparamref name="T"/>. 
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Gets all data of specific type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Return a query that get all data according to specific type <typeparamref name="T"/>.</returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Finds data according to specific condition and have type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="expression">Lambda expression</param>
        /// <returns>Returns a query that get all data according to specific condition.</returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Adds new entity to data source.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Create(T entity);

        /// <summary>
        /// Updates existed entity in data source.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(T entity);

        /// <summary>
        /// Deletes existed entity in data source.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);

        /// <summary>
        /// Makes entity unchanged in data source.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Attach(T entity);
    }
}
