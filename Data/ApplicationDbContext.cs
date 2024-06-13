using Encyklopediaa.Models.Objects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Encyklopediaa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Artykul> Artykul { get; set; }
        public DbSet<Gatunek> Gatunek { get; set; }
        //public DbSet<Multimedia> Multimedia { get; set; }
        public DbSet<Rodzina> Rodzina { get; set; }
        public DbSet<Siedlisko> Siedlisko { get; set; }
        public DbSet<Użytkownik> Użytkownik { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gatunek>()
                .HasMany(e => e.Siedliskos)
                .WithMany(e => e.Gatuneks);

            // Konfiguracja dla Gatunek
            modelBuilder.Entity<Gatunek>()
                .HasOne(g => g.Rodzina)
                .WithMany(g => g.Gatuneks)
                .HasForeignKey(g => g.RodzinaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Artykul>()
                .HasOne(a => a.Admin)
                .WithMany(a => a.Artykułss)
                .HasForeignKey(a => a.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Artykul>()
                .HasOne(a => a.Użytkownik)
                .WithMany(a => a.Artykułs)
                .HasForeignKey(a => a.UżytkownikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Artykul>()
                .HasOne(a => a.Rodzina)
                .WithMany(a => a.Artykułs)
                .HasForeignKey(a => a.RodzinaID)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Multimedia>()
            //.HasOne(m => m.Artykul)
            //.WithOne(a => a.Multimedia)
            //.HasForeignKey<Artykuł>(w => w.MultimediaId)
            //.OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Artykuł>()
            //.HasOne(a => a.Multimedia)
            //.WithOne(m => m.Artykul)
            //.HasForeignKey<Artykuł>(a => a.MultimediaId)
            //.OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Encyklopedia10DB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
    
}
