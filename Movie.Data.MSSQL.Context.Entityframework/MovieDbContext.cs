using Microsoft.EntityFrameworkCore;
using Movie.Data.MSSQL.Context.Entityframework.Configurations;
using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Context.Entityframework
{
    public partial class MovieDbContext : DbContext
    {

        public MovieDbContext()
        {
        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Directory> Directories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PPIBP5O;Database=movieTestDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            modelBuilder.ApplyConfiguration(new DirectoryConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
