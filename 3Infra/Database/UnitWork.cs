using _2Core.Interfaces.Infra.Database;
using _3Infra.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Infra.Database
{
    public class UnitWork : IUnitWork
    {
        private readonly DataContext _context;
        public UnitWork(DataContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public ITokenRepository TokenRepository => new TokenRepository(_context);

    }
}
