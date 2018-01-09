using Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class AcademyRepository : Repository<Academies>
    {
        public AcademyRepository(Entities _dbase) : base(_dbase.Academies, _dbase) { }

        public Academies GetByName(string name)
        {
            return All().FirstOrDefault(a => a.Name == name);
        }
    }
}