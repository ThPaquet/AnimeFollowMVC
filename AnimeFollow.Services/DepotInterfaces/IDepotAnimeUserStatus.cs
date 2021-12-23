using AnimeFollow.Services.Models;
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
        public IEnumerable<AnimeUserStatus> GetAnimeUserStatusesByUserId(int p_id);
        public AnimeUserStatus? GetAnimeUserStatus(int p_id);
        public void CreateAnimeUserStatus(AnimeUserStatus_DTO p_animeUserStatus);
        public void UpdateAnimeUserStatus(AnimeUserStatus_DTO p_animeUserStatus);
        public void DeleteAnimeUserStatus(int p_id);

    }
}
