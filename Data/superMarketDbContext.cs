using System;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Models;

namespace SuperMarket.Data
{
    public class superMarketDbContext:DbContext
    {
        public superMarketDbContext(DbContextOptions<superMarketDbContext> options) : base(options)
        { }

        public DbSet<employeeModel> employee { get; set; }
        public DbSet<stockModel> stocks { get; set; }
        public DbSet<eLevelModel> empLevel { get; set; }
    }
}
