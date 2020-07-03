using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Contracts
{
    /// <summary>
    /// Users repository interface that exposes the
    /// required methods to be implemented to provide
    /// basic statistics calculation for songs.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Obtains the count of the users registered
        /// in the database.
        /// </summary>
        /// <returns>total registered users count.</returns>
        Task<int> Count();
    }
}
