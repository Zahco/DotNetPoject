namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Evaluations : EntityWithId
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evaluations()
        {
            Results = new HashSet<Results>();
        }

        public Guid Classroom_Id { get; set; }

        public Guid User_Id { get; set; }

        public Guid Period_Id { get; set; }

        public DateTime Date { get; set; }

        public int TotalPoint { get; set; }

        public virtual Classrooms Classrooms { get; set; }

        public virtual Periods Periods { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }
    }
}
