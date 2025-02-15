using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2Core.Interfaces.Infra.Database;
using _1Domain.Entities;

namespace _3Infra.Database.Repositories
{
    public class UserRepository: _BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) 
        {
        }
    }
}
