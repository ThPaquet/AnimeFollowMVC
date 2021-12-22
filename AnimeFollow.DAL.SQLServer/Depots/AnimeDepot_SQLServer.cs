using AnimeFollowMVC.Services;
using AnimeFollowMVC.Services.DepotInterfaces;
using AnimeFollowMVC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFollowMVC.DAL.SQLServer.Depots
{
    public class AnimeDepot_SQLServer : IDepotAnime
    {
        private readonly AnimeFollowDBContext _context = new AnimeFollowDBContext();

        public IEnumerable<Anime> GetAnimes()
        {
            return this._context.Animes.ToArray();
        }

        public Anime? GetAnime(int p_id)
        {
            return this._context.Animes.Where(a => a.Id == p_id).SingleOrDefault();
        }

        public void CreateAnime(Anime p_anime)
        {
            if (p_anime is null)
            {
                throw new ArgumentNullException(nameof(p_anime));
            }

            this._context.Animes.Add(p_anime);
            this._context.SaveChanges();
        }

        public void UpdateAnime(Anime p_anime)
        {
            if (p_anime is null)
            {
                throw new ArgumentNullException(nameof(p_anime));
            }

            this._context.Animes.Update(p_anime);
            this._context.SaveChanges();
        }

        public void DeleteAnime(int p_id)
        {
            Anime? anime = this._context.Animes.FirstOrDefault(a => a.Id == p_id);

            if (anime is not null)
            {
                this._context.Animes.Remove(anime);
                this._context.SaveChanges();
            }
        }


    }
}
