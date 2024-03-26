using Exo_Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_FQ24L007_EntityFramework_Exo.Contexts;
using TF_FQ24L007_EntityFramework_Exo.Entities;

namespace TF_FQ24L007_EntityFramework_Exo.Services
{
    internal class FilmService : ICRUDRepository<Film, int>
    {
        /// <summary>
        /// Suppression d'un élément film grâce à son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du film</param>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Delete(int id)
        {
            try
            {
                using (ExoContext context = new ExoContext())
                {
                    Film? filmToRemove = context.Films.SingleOrDefault(f => f.FilmId == id);
                    if (filmToRemove is null) throw new ArgumentOutOfRangeException(nameof(id));
                    context.Films.Remove(filmToRemove);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Film> GetAll()
        {
            using (ExoContext context = new ExoContext())
            {
                return context.Films;
            }
        }

        public Film GetById(int id)
        {
            try
            {
                return GetOne(f => f.FilmId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Film> GetMany(Func<Film, bool> predicate)
        {
            using (ExoContext context = new ExoContext())
            {
                return context.Films.Where(predicate);
            }
        }

        public Film GetOne(Func<Film, bool> predicate)
        {
            try
            {
                using (ExoContext context = new ExoContext())
                {
                    Film? filmToFind = context.Films.SingleOrDefault(predicate);
                    if (filmToFind is null) throw new ArgumentException(nameof(predicate));
                    return filmToFind;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Film Insert(Film entity)
        {
            try
            {
                using (ExoContext context = new ExoContext())
                {
                    context.Films.Add(entity);
                    context.SaveChanges();
                    return entity;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Film Update(int id, Film entity)
        {
            try
            {
                using (ExoContext context = new ExoContext())
                {
                    Film filmToUpdate = GetById(id);
                    filmToUpdate.Titre = entity.Titre;
                    filmToUpdate.AnneeSortie = entity.AnneeSortie;
                    filmToUpdate.Realisateur = entity.Realisateur;
                    filmToUpdate.ActeurPrincipal = entity.ActeurPrincipal;
                    filmToUpdate.Genre = entity.Genre;
                    context.Update(filmToUpdate);
                    context.SaveChanges();
                    return filmToUpdate;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
