using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core;

namespace VFT.CMS.Repository.Data
{
    public class AppDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Categorys> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
