using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_FQ24L007_EntityFramework_Exo.Entities;

namespace TF_FQ24L007_EntityFramework_Exo.Configurations
{
    internal class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            //Définir nom de la table
            builder.ToTable("Films");

            //Définir clé primaire et auto-incrémenté
            builder.HasKey(f => f.FilmId);
            builder.Property(f => f.FilmId).ValueGeneratedOnAdd();

            //Titre doit être unique
            builder.HasIndex(f => f.Titre).IsUnique();

            //Les string non-null et limités à 100
            builder.Property(f => f.Titre)
                //.HasColumnName("Title")
                //.HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.Realisateur)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.ActeurPrincipal)
                .HasMaxLength(100)
                .IsRequired();

            //Contrainte check pour l'année >1975
            builder.ToTable(
                t => t.HasCheckConstraint("CK_Films_AnneeSortie", "AnneeSortie > 1975")
                );

        }
    }
}
