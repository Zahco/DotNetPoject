using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Academy.Repositories
{
    public class PupilRepository : Repository<Pupils>
    {
        public PupilRepository(Entities.Entities _dbase) : base(_dbase.Pupils, _dbase) { }
    }
}