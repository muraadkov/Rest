using System.Data.Entity;
using Restt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restt.Context
{
    public class RestContext : DbContext
    {
        public RestContext() : base("DbConnection") { }

        public DbSet<DictGenre> DictGenres { get; set; }
        public DbSet<Film> Films { get; set; }
        
    }
}
