using Diiage.Directory.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Diiage.Directory.Infrastructure.Database
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Mail>(entity =>
            {
                entity.ToTable("Mail");

                entity.Property(m => m.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValue();

                entity.Property(m => m.Recipient)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(m => m.Subject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(true);

                entity.Property(m => m.Body)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(true);
            });


            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.DirectoryId, "UQ_Employee_DirectoryId")
                    .IsUnique();

                entity.OwnsOne(
                    e => e.Address,
                    nav => {
                        nav.Property(a => a.Street)
                            .HasColumnName("AddressStreet")
                            .HasMaxLength(100)
                            .IsUnicode(false);
                        nav.Property(a => a.PostCode)
                            .HasColumnName("AddressPostCode")
                            .IsRequired()
                            .HasMaxLength(10)
                            .IsUnicode(false);
                        nav.Property(a => a.City)
                            .HasColumnName("AddressCity")
                            .IsRequired()
                            .HasMaxLength(100)
                            .IsUnicode(false);
                        nav.Property(a => a.Country)
                            .HasColumnName("AddressCountry")
                            .HasMaxLength(100)
                            .IsUnicode(false);
                    });

                entity.OwnsOne(
                    e => e.PersonalAddress,
                    nav => {
                        nav.Property(a => a.Street)
                            .HasColumnName("PersonalAddressStreet")
                            .HasMaxLength(100)
                            .IsUnicode(false);
                        nav.Property(a => a.PostCode)
                            .HasColumnName("PersonalAddressPostCode")
                            .IsRequired()
                            .HasMaxLength(10)
                            .IsUnicode(false);
                        nav.Property(a => a.City)
                            .HasColumnName("PersonalAddressCity")
                            .IsRequired()
                            .HasMaxLength(100)
                            .IsUnicode(false);
                        nav.Property(a => a.Country)
                            .HasColumnName("PersonalAddressCountry")
                            .HasMaxLength(100)
                            .IsUnicode(false);
                    });

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Comments)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.DirectoryId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PositionLevel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
