using System.Reflection;
using Microsoft.EntityFrameworkCore;
using org.huage.AuthManagement.DataBase.Table;

namespace org.huage.AuthManagement.DataBase.DBContext;

public class AuthDBContext : DbContext
{
    public DbSet<Role> Role { get; set; }
    public DbSet<Organization> Organization { get; set; }
    public DbSet<Permission> Permission { get; set; }


    public AuthDBContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}   