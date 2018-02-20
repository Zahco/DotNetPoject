using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Academy.Repositories
{
    public class PupilRepository : Repository<Pupils>
    {
        private ResultRepository resultRepository;

        public PupilRepository(Entities.Entities _dbase) : base(_dbase.Pupils, _dbase)
        {
            resultRepository = new ResultRepository(_dbase);
        }

        protected override void BeforeDelete(Pupils entity)
        {
            // Copy the lisf of Result to avoid problem during process.
            var list = entity.Results.ToList();
            foreach (var r in list)
            {
                resultRepository.Delete(r.Id);
            }
        }
    }
}