using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string uname, string pass)
        {
            var user = DataAccessFactory.AuthDataAccess().Authenticate(uname, pass);
            if (user != null)
            {
                var tok = new Token();
                tok.Uname = user.Uname;
                tok.CreateAt = DateTime.Now;
                tok.ExpiredAt = null;
                tok.Tkey = Guid.NewGuid().ToString();
                var rttk = DataAccessFactory.TokenDataAccess().Add(tok);
                if (rttk != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }
            }
            return null;
        }
        public static bool IsTokenValid(string token, int utype)
        {
            var tok = DataAccessFactory.TokenDataAccess().Get(token);

            if (tok != null && tok.ExpiredAt == null)
            {
                return true;
            }
            return false;


        }
    }
}

