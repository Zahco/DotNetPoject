using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class AcademyRepository : Repository<Academies>
    {
        private EstablishmentRepository establishmentRepository;

        public AcademyRepository(Entities.Entities _dbase) : base(_dbase.Academies, _dbase)
        {
            establishmentRepository = new EstablishmentRepository(_dbase);
        }

        public Academies GetByName(string name)
        {
            return All().FirstOrDefault(a => a.Name == name);
        }

        protected override void BeforeDelete(Academies entity)
        {
            // Copy the lisf of Establishment to avoid problem during process.
            var list = entity.Establishments.ToList();
            foreach (var e in list)
            {
                establishmentRepository.Delete(e.Id);
            }
        }
    }
}