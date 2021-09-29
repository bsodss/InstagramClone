using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InstagramClone.DAL
{
     public class InstagramCloneDbContextFactory:IDesignTimeDbContextFactory<InstagramCloneDbContext>
    {
        public InstagramCloneDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InstagramCloneDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.\;Database=db;Trusted_Connection=True;",
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new InstagramCloneDbContext(optionsBuilder.Options);

        }
    }
}
