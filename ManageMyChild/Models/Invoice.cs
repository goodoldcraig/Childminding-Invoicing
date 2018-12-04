namespace ManageMyChild.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            Parents = new HashSet<Parent>();
        }

        public int Id { get; set; }

        public string Comment { get; set; }

        public int ChildId { get; set; }

        [Required]
        [StringLength(128)]
        public string CareerId { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]

        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Charge { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Child Child { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parent> Parents { get; set; }
    }
}
