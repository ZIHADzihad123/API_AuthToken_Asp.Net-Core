using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static tokenBasedApiContext db;
        static DataAccessFactory()
        {
            db = new tokenBasedApiContext();
        }
        public static IRepository<Blog, int> BlogsDataAccess() {
            return new BlogsRepo(db);
        }
        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepository<Token, string> TokenDataAccess()
        {
            return new TokenRepo(db);
        }
        public static IAuth AuthDataAccess() {
            return new AuthRepo(db);
        }
    }
}
