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
    public class AnimeUserStatusDepot_SQLServer : IDepotAnimeUserStatus
    {
        private readonly AnimeFollowDBContext _context = new AnimeFollowDBContext();

        public IEnumerable<AnimeUserStatus> GetAnimeUserStatuses()
        {
            return this._context.AnimeUserStatuses.ToArray();
        }
        public AnimeUserStatus? GetAnimeUserStatus(int p_id)
        {
            return this._context.AnimeUserStatuses
                .SingleOrDefault(a => a.Id == p_id);
        }

        public void CreateAnimeUserStatus(AnimeUserStatus p_animeUserStatus)
        {
            if (p_animeUserStatus == null)
            {
                throw new ArgumentNullException(nameof(p_animeUserStatus));
            }

            this._context.AnimeUserStatuses.Add(p_animeUserStatus);
            this._context.SaveChanges();
        }

        public void UpdateAnimeUserStatus(AnimeUserStatus p_animeUserStatus)
        {
            if (p_animeUserStatus == null)
            {
                throw new ArgumentNullException(nameof(p_animeUserStatus));
            }

            this._context.AnimeUserStatuses.Update(p_animeUserStatus);
            this._context.SaveChanges();
        }

        public void DeleteAnimeUserStatus(int p_id)
        {
            AnimeUserStatus? animeUserStatus = this._context.AnimeUserStatuses
                .SingleOrDefault(a => a.Id == p_id);

            if (animeUserStatus is not null)
            {
                this._context.AnimeUserStatuses.Remove(animeUserStatus);
                this._context.SaveChanges();
            }
        }
        
    }
}
