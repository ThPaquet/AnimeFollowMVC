using AnimeFollowMVC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFollowMVC.Services.DepotInterfaces
{
    public interface IDepotAnimeUserStatus
    {
        public IEnumerable<AnimeUserStatus> GetAnimeUserStatuses();
        public AnimeUserStatus? GetAnimeUserStatus(int p_id);
        public void CreateAnimeUserStatus(AnimeUserStatus p_animeUserStatus);
        public void UpdateAnimeUserStatus(AnimeUserStatus p_animeUserStatus);
        public void DeleteAnimeUserStatus(int p_id);

    }
}
