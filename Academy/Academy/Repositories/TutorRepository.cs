using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class TutorRepository : Repository<Tutors>
    {
        private PupilRepository PupilRepository;

        public TutorRepository(Entities.Entities _dbase) : base(_dbase.Tutors, _dbase)
        {
            PupilRepository = new PupilRepository(_dbase);
        }

        protected override void BeforeDelete(Tutors entity)
        {
            var pupils = entity.Pupils.ToList();
            foreach(var pupil in pupils)
            {
                PupilRepository.Delete(pupil.Id);
            }
        }
    }
}