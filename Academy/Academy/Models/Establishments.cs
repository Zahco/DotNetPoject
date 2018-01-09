namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Establishments : EntityWithId
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Establishments()
        {
            Classrooms = new HashSet<Classrooms>();
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string PostCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Town { get; set; }

        public Guid User_Id { get; set; }

        public Guid Academie_Id { get; set; }

        public virtual Academies Academies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classrooms> Classrooms { get; set; }

        public virtual Users Users { get; set; }
    }
}
