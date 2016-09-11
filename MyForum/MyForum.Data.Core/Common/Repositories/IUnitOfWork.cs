using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Data.Core.Common.Repositories
{
    /// <summary>
    /// Class <see cref="IUnitOfWork"/> that handles multiple Repositories
    /// This is not specific to which Data Access
    /// tools your are using (Direct SQL, EF, NHibernate, etc)
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit all changes
        /// </summary>
        void Commit();
    }
}
