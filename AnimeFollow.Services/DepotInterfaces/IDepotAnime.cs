using AnimeFollowMVC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFollowMVC.Services.DepotInterfaces
{
    public interface IDepotAnime
    {
        public IEnumerable<Anime> GetAnimes();
        public Anime? GetAnime(int p_id);
        public void CreateAnime(Anime p_anime);
        public void UpdateAnime(Anime p_anime);
        public void DeleteAnime(int p_id);
    }
}
