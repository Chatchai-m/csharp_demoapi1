using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2Core.Interfaces.Infra.Database;
using _1Domain.Entities;

namespace _3Infra.Database.Repositories
{
    public class CarRepository: _BaseRepository<Car>, ICarRepository
    {
        public CarRepository(DataContext context) : base(context) 
        {
        }
    }
}
