using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class PeriodRepository : Repository<Periods>
    {
        public PeriodRepository(Entities.Entities _dbase) : base(_dbase.Periods, _dbase) { }
    }
}