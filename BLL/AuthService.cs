using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.EF;

namespace BLL
{
    public class AuthService
    {
        static AuthService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Token, TokenModel>();
                cfg.CreateMap<TokenModel, Token>();
            });
        }
        public static TokenModel Auth(string name,string pass)
        {
            var data = DataAccessFactory.AuthDataAccess().FindUser(name,pass);
            var db_user = Mapper.Map<User>(data);
            var token = DataAccessFactory.AuthDataAccess().Authenticate(db_user);
            var tokenModel = Mapper.Map<TokenModel>(token);
            return tokenModel;
            //convert user model to user
            //then send to auth repo
        }
        public static bool CheckValidityToken(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return rs;
        }
        public static bool Logout(string token)
        {
            return DataAccessFactory.AuthDataAccess().Logout(token);
        }
    }
}
