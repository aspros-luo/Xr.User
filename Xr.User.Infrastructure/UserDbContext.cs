using System.Reflection;
using Aspros.Base.Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Xr.User.Infrastructure
{
    public class UserDbContext(DbContextOptions options) : DbContext(options), IDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
}