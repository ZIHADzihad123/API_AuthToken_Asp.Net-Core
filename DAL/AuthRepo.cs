using DAL.EF;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthRepo : IAuth
    {
        tokenBasedApiContext db;

        public AuthRepo(tokenBasedApiContext db) {
            this.db = db;
        }
        public Token Authenticate(User us)
        {
            Token t=null;
           // var u =db.Users.FirstOrDefault(e => e.Username == us.Username  && e.Password == us.Password);
            if (us != null) {
                var r = new Random();
                var g = Guid.NewGuid();
                var token = g.ToString();
                
                t = new Token()
                {
                    UserId = us.Id,
                    AccessToken = token,
                    CreatedAt = DateTime.Now

                };


               

               db.Tokens.Add(t);
                db.SaveChanges();

            }

            return t;

        }

        public User FindUser(string name, string pass)
        {
            
               var  u = db.Users.FirstOrDefault(e => e.Username == name && e.Password == pass);
            if (u != null)
            {
                return u;
            }
            else
            {
                return u=null;
            }
           
        }

        public bool IsAuthenticated(string token) {
            var ac_token = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token) && e.ExpiredAt == null);
            if (ac_token != null) return true;
            return false;

        }

        public bool Logout(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token));
            if (t != null)
            {
                t.ExpiredAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
