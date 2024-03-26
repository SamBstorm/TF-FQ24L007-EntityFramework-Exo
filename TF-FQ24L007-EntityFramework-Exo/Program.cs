using Exo_Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using TF_FQ24L007_EntityFramework_Exo.Entities;
using TF_FQ24L007_EntityFramework_Exo.Services;

ICRUDRepository<Film, int> repository = new FilmService();

Film film1 = new Film() { 
    Titre = "Jurassic Park",
    AnneeSortie = 1993,
    Realisateur = "Steven Speilberg",
    ActeurPrincipal = "Sam Neil",
    Genre = (Genre)10
};

try
{
	film1 = repository.Insert(film1);
}
catch (DbUpdateException ex)
{
    Console.WriteLine(ex.InnerException.Message);
    film1 = repository.GetOne(f => f.Titre == film1.Titre);
}

Console.WriteLine(film1);

film1.ActeurPrincipal = "Sam Neil, Laura Dern, Jeff Goldblum";

repository.Update(film1.FilmId, film1);

Console.WriteLine(repository.GetById(film1.FilmId));