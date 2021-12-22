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
    public class UserDepot_SQLServer : IDepotUsers
    {
        private readonly AnimeFollowDBContext _context = new AnimeFollowDBContext();
        public IEnumerable<User> GetUsers()
        {
            return this._context.Users.ToArray();
        } 

        public User? GetUser(int p_id)
        {
            return this._context.Users.SingleOrDefault(u => u.Id == p_id);
        }


        public void CreateUser(User p_user)
        {
            if (p_user == null)
            {
                throw new ArgumentNullException(nameof(p_user));
            }

            this._context.Users.Add(p_user);
            this._context.SaveChanges();
        }

        public void UpdateUser(User p_user)
        {
            if (p_user != null)
            {
                this._context.Users.Update(p_user);
                this._context.SaveChanges();
            }
        }
        public void DeleteUser(int p_id)
        {
            User? user = this._context.Users.SingleOrDefault(u => u.Id == p_id);   

            if (user is not null)
            {
                this._context.Users.Remove(user);
                this._context.SaveChanges();
            }
        }
    }
}
