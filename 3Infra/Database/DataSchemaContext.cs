using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Infra.Database
{
    public class DataSchemaContext : DataContext
    {
        public DataSchemaContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //string connection_string = "Server=localhost;Initial Catalog=demo_api_schema;User ID=mos;Password=123456;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=180;";
            //options.UseSqlServer(connection_string);

            string connection_string = "Server=localhost;Port=5432;Database=demo_api_schema;User Id=postgres;Password=1234";
            options.UseNpgsql(connection_string);
        }
    }
}
