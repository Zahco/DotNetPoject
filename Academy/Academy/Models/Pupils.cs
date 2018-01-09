namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pupils : EntityWithId
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pupils()
        {
            Results = new HashSet<Results>();
        }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public short Sex { get; set; }

        public DateTime BirthdayDate { get; set; }

        public short State { get; set; }

        public Guid Tutor_Id { get; set; }

        public Guid Classroom_Id { get; set; }

        public Guid Level_Id { get; set; }

        public virtual Classrooms Classrooms { get; set; }

        public virtual Levels Levels { get; set; }

        public virtual Tutors Tutors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }
    }
}
