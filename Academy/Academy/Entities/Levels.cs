namespace Academy.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Levels : EntityWithId
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Levels()
        {
            Pupils = new HashSet<Pupils>();
        }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public Guid Cycle_Id { get; set; }

        public virtual Cycles Cycles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pupils> Pupils { get; set; }
    }
}
