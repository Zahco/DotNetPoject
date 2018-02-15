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
        private ResultRepository resultRepository;

        public EvaluationRepository(Entities.Entities _dbase) : base(_dbase.Evaluations, _dbase)
        {
            resultRepository = new ResultRepository(_dbase);
        }

        protected override void BeforeDelete(Evaluations entity)
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