using Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class UserRepository : Repository<Users>
    {
        public UserRepository(Entities _dbase) : base(_dbase.Users, _dbase) { }
    }
}