using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_ma495.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base (options)
        {

        }

        public DbSet<ApplicationResponse> responses { get; set; }
    }
}
