﻿using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class UserRepo : Repo, IRepo<User, int>, IAuth
    {
        public bool Add(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }



        public User Authenticate(string uname, string pass)
        {
            var obj = db.Users.FirstOrDefault(x => x.Uname.Equals(uname) && x.Password.Equals(pass));
            return obj;
        }

        public bool Delete(int id)
        {

            var dbuser = Get(id);
            db.Users.Remove(dbuser);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var dbuser = Get(obj.Id);
            db.Entry(dbuser).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
