using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Contracts
{
    /// <summary>
    /// General purpose Repository interface to use as base for all the
    /// repositories to be created to fetch entity data from the data
    /// access layer.
    /// </summary>
    /// <typeparam name="T">Entity Type of the repository</typeparam>
    /// <typeparam name="U">Primary key type of the entity</typeparam>
    public interface IRepository<T, U> 
        where T : class
    {
        /// <summary>
        /// Contract to get all the records available for the given entity
        /// </summary>
        /// <returns>A collection of all T entity instances available</returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Contract to get a single entity instance by the given Id.
        /// </summary>
        /// <param name="Id">The Id of the entity to fetch</param>
        /// <returns>A single entity value.</returns>
        Task<T> FindById(U Id);
        /// <summary>
        /// Contract to get all the records avaiable for the given entity
        /// that matches the lambda expression passed as parameter.
        /// </summary>
        /// <param name="exp">lambda expression to filter result.</param>
        /// <returns>A filtered colletion by the exp clause.</returns>
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> exp);
    }
}
