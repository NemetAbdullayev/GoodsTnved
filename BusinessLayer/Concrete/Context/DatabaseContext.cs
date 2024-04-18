using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("Db");
        }
    }
}
