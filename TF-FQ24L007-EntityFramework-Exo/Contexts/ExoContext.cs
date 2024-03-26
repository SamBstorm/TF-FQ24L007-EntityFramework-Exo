using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_FQ24L007_EntityFramework_Exo.Configurations;
using TF_FQ24L007_EntityFramework_Exo.Entities;

namespace TF_FQ24L007_EntityFramework_Exo.Contexts
{
    internal class ExoContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExoEntity;Integrated Security=True;Encrypt=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
        }
    }
}
