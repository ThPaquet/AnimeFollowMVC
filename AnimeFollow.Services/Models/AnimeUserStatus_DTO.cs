using AnimeFollowMVC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFollow.Services.Models
{
    public class AnimeUserStatus_DTO
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public int UserId { get; set; }
        public int LastEpisodeWatched { get; set; }
        public Uri URISourceAnime { get; set; }
        public int CurrentNote { get; set; }
    }
}
