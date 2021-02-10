using Microsoft.EntityFrameworkCore;
using TODO_API.Domain.Entities;

namespace TODO_API.Domain.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todo");
            modelBuilder.Entity<Todo>().Property(x=>x.Id);
            modelBuilder.Entity<Todo>().Property(x=>x.User).HasColumnType("varchar(120)");
            modelBuilder.Entity<Todo>().Property(x=>x.Title).HasColumnType("varchar(160)");
            modelBuilder.Entity<Todo>().Property(x=>x.Done).HasColumnType("bit");
            modelBuilder.Entity<Todo>().Property(x=>x.Date);
            modelBuilder.Entity<Todo>().HasIndex(index=>index.User);
        }
    }
}