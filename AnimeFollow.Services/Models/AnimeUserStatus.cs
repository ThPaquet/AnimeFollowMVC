using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFollowMVC.Services.Models
{
    public class AnimeUserStatus
    {
        public int Id { get; set; }
        public Anime? Anime { get; set; }
        public User? User { get; set; }
        public int DernierEpisodeEcoute { get; set; }
        public Uri URISourceAnime { get; set; }
        public int CurrentNote { get; set; }
    }
}
