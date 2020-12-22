using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Movie.Models
{
    public partial class MovieDbContext : DbContext
    {
        public MovieDbContext()
            : base("name=MovieDbContext")
        {
        }

        public virtual DbSet<About_Us> About_Us { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<SubMenu> SubMenus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About_Us>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<About_Us>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<About_Us>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Avartar)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Twitter)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Facebook)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Dribbble)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Google)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Avartar)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Avartar)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.Metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Metatite)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<SubMenu>()
                .Property(e => e.Metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<SubMenu>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);
        }
    }
}
