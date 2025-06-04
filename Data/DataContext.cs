using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<BookingEntity> Bookings { get; set; }
    public DbSet<TicketEntity> Tickets { get; set; }
    public DbSet<InvoiceEntity> Invoices { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketEntity>()
            .HasOne(t => t.Booking)
            .WithMany(b => b.Tickets)
            .HasForeignKey(t => t.BookingId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<InvoiceEntity>()
            .HasOne(i => i.Booking)
            .WithOne(b => b.Invoice)
            .HasForeignKey<InvoiceEntity>(i => i.BookingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
