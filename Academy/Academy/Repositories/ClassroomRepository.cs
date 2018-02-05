using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class ClassroomRepository : Repository<Classrooms>
    {
        public ClassroomRepository(Entities.Entities _dbase) : base(_dbase.Classrooms, _dbase) { }

        public Classrooms GetByTitle(string name)
        {
            return All().FirstOrDefault(c => c.Title == name);
        }
    }
}