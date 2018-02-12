using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class ClassroomRepository : Repository<Classrooms>
    {
        private EstablishmentRepository EstablishmentRepository;

        public ClassroomRepository(Entities.Entities _dbase) : base(_dbase.Classrooms, _dbase)
        {
            EstablishmentRepository = new EstablishmentRepository(_dbase);
        }

        public Classrooms GetByTitle(string name)
        {
            return All().FirstOrDefault(c => c.Title == name);
        }

        public Establishments GetByEstablishment(Guid establishmentId)
        {
            return EstablishmentRepository.All()
                .FirstOrDefault(e => e.Id == establishmentId);
        }        
    }
}