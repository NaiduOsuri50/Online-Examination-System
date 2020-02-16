namespace aspire1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Option
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Option()
        {
            AnsweredQuestions = new HashSet<AnsweredQuestion>();
            CorrectAnswers = new HashSet<CorrectAnswer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OptionId { get; set; }

        [Column("Option")]
        public int Option1 { get; set; }

        public int QuestionsId { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnsweredQuestion> AnsweredQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorrectAnswer> CorrectAnswers { get; set; }

        public virtual Question Question { get; set; }
    }
}
