using Keeper.Context.Model;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Context
{
    public class DbKeeperContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<KeepModel> Keeps { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbKeeperContext(DbContextOptions options): base(options) { }
    }
}
