using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class TutorRepository : Repository<Tutors>
    {
        public TutorRepository(Entities.Entities _dbase) : base(_dbase.Tutors, _dbase) { }
    }
}