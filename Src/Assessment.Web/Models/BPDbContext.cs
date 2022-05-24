using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Web.Models
{
    class BPDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }

        protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("datasource =.; initial catalog = Sample; integrated security = true");
        }
    }
}
