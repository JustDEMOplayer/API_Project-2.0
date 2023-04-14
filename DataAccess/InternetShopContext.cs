using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess.Context
{
    public partial class InternetShopContext : DbContext
    {
        public InternetShopContext()
        {
        }

        public InternetShopContext(DbContextOptions<InternetShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Filter> Filters { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<GoodCharachteristic> GoodCharachteristics { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GoodId })
                    .HasName("PK__Carts__D7CB621F24A5166A");

                entity.Property(e => e.Count).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carts__GoodId__30F848ED");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carts__UserId__300424B4");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Categorie__Paren__2D27B809");
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Filters)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Filters__Categor__3C69FB99");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Goods)
                    .UsingEntity<Dictionary<string, object>>(
                        "GoodCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__GoodCateg__Categ__398D8EEE"),
                        r => r.HasOne<Good>().WithMany().HasForeignKey("GoodId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__GoodCateg__GoodI__38996AB5"),
                        j =>
                        {
                            j.HasKey("GoodId", "CategoryId").HasName("PK__GoodCate__A5AA769D77C659E6");

                            j.ToTable("GoodCategories");
                        });
            });

            modelBuilder.Entity<GoodCharachteristic>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Value).HasColumnType("sql_variant");

                entity.HasOne(d => d.FilterIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FilterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GoodChara__Filte__3F466844");

                entity.HasOne(d => d.Good)
                    .WithMany()
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GoodChara__GoodI__3E52440B");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeliveryMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullCost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IsDeleted).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__34C8D9D1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534BF8BD286")
                    .IsUnique();

                entity.Property(e => e.Balance).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleteted).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('User')");

                entity.Property(e => e.Surname)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}