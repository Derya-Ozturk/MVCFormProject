using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public partial class MVCContext: DbContext
    {
        public readonly string? connection;
        public MVCContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                           .AddJsonFile("appsettings.json")
                           .Build();

            connection = configuration.GetConnectionString("DefaultConnection");
        }

        public MVCContext(DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Field> Fields { get; set; }

        public virtual DbSet<Form> Forms { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlServer(connection);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>(entity =>
            {
                entity.ToTable("Field");

                entity.Property(e => e.DataType).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Form).WithMany(p => p.Fields)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_Field_Form");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("Form");

                entity.Property(e => e.CreatedAt).HasMaxLength(10);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Forms)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Form_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password).HasMaxLength(20);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
