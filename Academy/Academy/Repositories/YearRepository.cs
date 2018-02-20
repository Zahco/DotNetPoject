using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class YearRepository : Repository<Years>
    {
        public YearRepository(Entities.Entities _dbase) : base(_dbase.Years, _dbase) { }
    }
}