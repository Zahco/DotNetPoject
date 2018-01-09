using Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class ClassroomRepository : Repository<Classrooms>
    {
        public ClassroomRepository(Entities _dbase) : base(_dbase.Classrooms, _dbase) { }
    }
}