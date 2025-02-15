using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Interfaces.Infra.Database
{
    public interface IUnitWork
    {
        Task CommitAsync();
        IUserRepository UserRepository { get; }
        ITokenRepository TokenRepository { get; }
    }
}
