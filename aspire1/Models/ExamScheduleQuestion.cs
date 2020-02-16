namespace aspire1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExamScheduleQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExamScheduleQuestionsId { get; set; }

        public int QuestionId { get; set; }

        public int ExamScheduleId { get; set; }

        public virtual ExamSchedule ExamSchedule { get; set; }

        public virtual Question Question { get; set; }
    }
}
