using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAuth
    {
        Token Authenticate(User us);
        bool IsAuthenticated(string token);
        bool Logout(string token);
        User FindUser(string username,string pass);
    }
}
