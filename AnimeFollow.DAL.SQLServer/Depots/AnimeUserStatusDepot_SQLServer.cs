using AnimeFollow.Services.Models;
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
            IEnumerable<AnimeUserStatus_DTO> DTOs = this._context.AnimeUserStatuses.ToArray();

            return DTOs
                .Select(d => ToEntity(d))
                .ToArray();
        }

        public IEnumerable<AnimeUserStatus> GetAnimeUserStatusesByUserId(int p_id)
        {
            IEnumerable<AnimeUserStatus_DTO> DTOs = this._context.AnimeUserStatuses
                .Where(d => d.UserId == p_id);

            return DTOs
                .Select(d => ToEntity(d))
                .ToArray();
        }

        public AnimeUserStatus? GetAnimeUserStatus(int p_id)
        {
            return ToEntity(this._context.AnimeUserStatuses
                .SingleOrDefault(a => a.Id == p_id));
        }

        public void CreateAnimeUserStatus(AnimeUserStatus_DTO p_animeUserStatus)
        {
            if (p_animeUserStatus == null)
            {
                throw new ArgumentNullException(nameof(p_animeUserStatus));
            }


            this._context.AnimeUserStatuses.Add(p_animeUserStatus);
            this._context.SaveChanges();
        }

        public void UpdateAnimeUserStatus(AnimeUserStatus_DTO p_animeUserStatus)
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
            AnimeUserStatus_DTO? animeUserStatus = this._context.AnimeUserStatuses
                .SingleOrDefault(a => a.Id == p_id);

            if (animeUserStatus is not null)
            {
                this._context.AnimeUserStatuses.Remove(animeUserStatus);
                this._context.SaveChanges();
            }
        }

        private AnimeUserStatus ToEntity(AnimeUserStatus_DTO p_post)
        {
            return new AnimeUserStatus
            {
                //Id = 0,
                Anime = this._context.Animes.SingleOrDefault(a => a.Id == p_post.AnimeId),
                User = this._context.Users.SingleOrDefault(u => u.Id == p_post.UserId),
                CurrentNote = p_post.CurrentNote,
                DernierEpisodeEcoute = p_post.CurrentNote,
                URISourceAnime = p_post.URISourceAnime,
            };
        }
        
    }
}
