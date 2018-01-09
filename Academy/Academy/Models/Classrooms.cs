namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Classrooms : EntityWithId
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classrooms()
        {
            Evaluations = new HashSet<Evaluations>();
            Pupils = new HashSet<Pupils>();
        }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public Guid User_Id { get; set; }

        public Guid Year_Id { get; set; }

        public Guid Establishment_Id { get; set; }

        public virtual Establishments Establishments { get; set; }

        public virtual Users Users { get; set; }

        public virtual Years Years { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluations> Evaluations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pupils> Pupils { get; set; }
    }
}
