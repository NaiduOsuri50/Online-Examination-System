namespace aspire1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnsweredQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnsId { get; set; }

        public int ExamScheduleStudentsId { get; set; }

        public int QuestionsId { get; set; }

        public int OptionsId { get; set; }

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

        public virtual ExamSchedule ExamSchedule { get; set; }

        public virtual Option Option { get; set; }
    }
}
