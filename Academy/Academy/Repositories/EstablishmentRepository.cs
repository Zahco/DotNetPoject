using Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class EstablishmentRepository : Repository<Establishments>
    {
        public EstablishmentRepository(Entities _dbase) : base(_dbase.Establishments, _dbase) { }
        public Establishments GetByName(string name)
        {
            return All().FirstOrDefault(a => a.Name == name);
        }
    }
}