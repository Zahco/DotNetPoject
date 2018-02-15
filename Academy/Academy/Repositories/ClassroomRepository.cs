using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class ClassroomRepository : Repository<Classrooms>
    {
        private EstablishmentRepository establishmentRepos

        public ClassroomRepository(Entities.Entities _dbase) : base(_dbase.Classrooms, _dbase)
        {
            establishmentRepository = new EstablishmentRepository(_dbase);
        }

        public Classrooms GetByTitle(string name)
        {
            return All().FirstOrDefault(c => c.Title == name);
        }

        public Establishments GetByEstablishment(Guid establishmentId)
        {
            return establishmentRepository.All()
                .FirstOrDefault(e => e.Id == establishmentId);
        }
    }
}