﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cms_net.Context
{
    public class CMSContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentDefinition> ComponentDefinitions { get; set; }
        public DbSet<Field> Fields { get; set; }

        public CMSContext(DbContextOptions<CMSContext> options)
        : base(options)
        {
        }

        public CMSContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=cms-net;Integrated Security=True");
        }

    }
}
