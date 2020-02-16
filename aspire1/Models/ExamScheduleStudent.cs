namespace aspire1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExamScheduleStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExamScheduleStudentsId { get; set; }

        public int ExamScheduleId { get; set; }

        public int StudentsId { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastModifiedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public virtual ExamSchedule ExamSchedule { get; set; }

        public virtual StudentsDetail StudentsDetail { get; set; }
    }
}
