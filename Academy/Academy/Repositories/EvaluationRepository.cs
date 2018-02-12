using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Academy.Repositories
{
    public class EvaluationRepository : Repository<Evaluations>
    {
        public EvaluationRepository(Entities.Entities _dbase) : base(_dbase.Evaluations, _dbase)
        {
        }


    }
}