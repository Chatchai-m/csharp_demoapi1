using _2Core.Interfaces.Infra.Database;
using _1Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Infra.Database.Repositories
{
    public class TokenRepository: _BaseRepository<Token>, ITokenRepository
    {
        public TokenRepository(DataContext context) : base(context)
        {
        }
    }
}
