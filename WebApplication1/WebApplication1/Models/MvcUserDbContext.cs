using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Models;

public partial class MvcUserDbContext : DbContext
{
    public MvcUserDbContext()
    {
    }

    public MvcUserDbContext(DbContextOptions<MvcUserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    
    
    
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserTable");

            entity.Property(e => e.UserBirthDay).HasColumnType("datetime");
            entity.Property(e => e.UserMobilePhone).HasMaxLength(15);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserSex)
                .HasMaxLength(1)
                .HasDefaultValueSql("(N'M')")
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
