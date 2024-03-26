using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_FQ24L007_EntityFramework_Exo.Entities
{
    internal class Film
    {
        public int FilmId { get; set; }
        public string Titre { get; set; }
        public int AnneeSortie { get; set; }
        public string Realisateur { get; set; }
        public string ActeurPrincipal { get; set; }
        public Genre Genre { get; set; }

        public override string ToString()
        {
            string genres = "";
            foreach (Genre genre in Enum.GetValues<Genre>())
            {
                if (this.Genre.HasFlag(genre))
                {
                    genres += genre + ",";
                }
            }
            return 
@$"FilmId : {FilmId}
Titre : {Titre}
Année de sortie : {AnneeSortie}
Réalisateur : {Realisateur}
Acteur principal : {ActeurPrincipal}
Genres : {genres}";

        }
    }
}
