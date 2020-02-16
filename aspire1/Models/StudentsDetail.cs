namespace aspire1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentsDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentsDetail()
        {
            ExamScheduleStudents = new HashSet<ExamScheduleStudent>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentsId { get; set; }

        [Required]
        [StringLength(30)]
        public string StudentsName { get; set; }

        [Required]
        [StringLength(30)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(10)]
        public string Contact { get; set; }

        [Column(TypeName = "date")]
        public DateTime YearOfPassing { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(10)]
        public string StudentsCategory { get; set; }

        public int StudentsBatchId { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastModifiedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public virtual BatchDetail BatchDetail { get; set; }

        public virtual BatchDetail BatchDetail1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamScheduleStudent> ExamScheduleStudents { get; set; }
    }
}
