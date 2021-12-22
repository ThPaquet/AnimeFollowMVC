using AnimeFollowMVC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFollowMVC.Services.DepotInterfaces
{
    public interface IDepotUsers
    {
        public IEnumerable<User> GetUsers();
        public User? GetUser(int p_id);
        public void CreateUser(User p_user);
        public void UpdateUser(User p_user);
        public void DeleteUser(int p_id);
    }
}
