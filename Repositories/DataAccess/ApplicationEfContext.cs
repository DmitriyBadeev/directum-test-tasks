using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

internal sealed class ApplicationEfContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Contact> Contacts { get; set; } = default!;
    public DbSet<Message> Messages { get; set; } = default!;

    public ApplicationEfContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Or UseSqlServer(WellKnow.MssqlConnectionString)
        optionsBuilder.UseNpgsql(WellKnow.PostgresConnectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .HasOne(p => p.ContactUser)
            .WithMany(t => t.LinkedContacts)
            .HasForeignKey(p => p.ContactUserId);
        
        modelBuilder.Entity<Contact>()
            .HasOne(p => p.User)
            .WithMany(t => t.Contacts)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<Message>()
            .HasOne(p => p.User)
            .WithMany(t => t.SendMessages)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<Message>()
            .HasOne(p => p.ReceiveUser)
            .WithMany(t => t.ReceiveMessages)
            .HasForeignKey(p => p.ReceiveUserId);
    }
}