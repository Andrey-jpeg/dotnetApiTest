using System;
using Microsoft.EntityFrameworkCore;

namespace restApi.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) 
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
