using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class LevelRepository : Repository<Levels>
    {
        public LevelRepository(Entities.Entities _dbase) : base(_dbase.Levels, _dbase) { }
    }
}