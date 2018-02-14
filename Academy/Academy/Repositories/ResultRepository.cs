using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class ResultRepository : Repository<Results>
    {
        public ResultRepository(Entities.Entities _dbase) : base(_dbase.Results, _dbase) { }
    }
}