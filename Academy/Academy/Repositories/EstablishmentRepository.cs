using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Repositories
{
    public class EstablishmentRepository : Repository<Establishments>
    {
        //private ClassroomRepository classroomRepository;

        public EstablishmentRepository(Entities.Entities _dbase) : base(_dbase.Establishments, _dbase)
        {
            //classroomRepository = new ClassroomRepository(_dbase);
        }
        public Establishments GetByName(string name)
        {
            return All().FirstOrDefault(a => a.Name == name);
        }

        //protected override void BeforeDelete(Establishments entity)
        //{
        //    // Copy the lisf of Classroom to avoid problem during process.
        //    var list = entity.Classrooms.ToList();
        //    foreach (var c in list)
        //    {
        //        classroomRepository.Delete(c.Id);
        //    }
        //}
    }
}