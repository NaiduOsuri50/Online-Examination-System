namespace aspire1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=aspireminds")
        {
        }

        public virtual DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BatchDetail> BatchDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CorrectAnswer> CorrectAnswers { get; set; }
        public virtual DbSet<ExamDetail> ExamDetails { get; set; }
        public virtual DbSet<ExamSchedule> ExamSchedules { get; set; }
        public virtual DbSet<ExamScheduleQuestion> ExamScheduleQuestions { get; set; }
        public virtual DbSet<ExamScheduleStudent> ExamScheduleStudents { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<StudentsDetail> StudentsDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BatchDetail>()
                .Property(e => e.StudentsBatchName)
                .IsFixedLength();

            modelBuilder.Entity<BatchDetail>()
                .HasMany(e => e.StudentsDetails)
                .WithRequired(e => e.BatchDetail)
                .HasForeignKey(e => e.StudentsBatchId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BatchDetail>()
                .HasMany(e => e.StudentsDetails1)
                .WithRequired(e => e.BatchDetail1)
                .HasForeignKey(e => e.StudentsBatchId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.ExamDetails)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamDetail>()
                .HasMany(e => e.ExamSchedules)
                .WithRequired(e => e.ExamDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamSchedule>()
                .HasMany(e => e.AnsweredQuestions)
                .WithRequired(e => e.ExamSchedule)
                .HasForeignKey(e => e.ExamScheduleStudentsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamSchedule>()
                .HasMany(e => e.ExamScheduleQuestions)
                .WithRequired(e => e.ExamSchedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamSchedule>()
                .HasMany(e => e.ExamScheduleStudents)
                .WithRequired(e => e.ExamSchedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Option>()
                .HasMany(e => e.AnsweredQuestions)
                .WithRequired(e => e.Option)
                .HasForeignKey(e => e.OptionsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Option>()
                .HasMany(e => e.CorrectAnswers)
                .WithRequired(e => e.Option)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.ExamScheduleQuestions)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Options)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.QuestionsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasOptional(e => e.Questions1)
                .WithRequired(e => e.Question2);

            modelBuilder.Entity<StudentsDetail>()
                .Property(e => e.StudentsName)
                .IsFixedLength();

            modelBuilder.Entity<StudentsDetail>()
                .Property(e => e.EmailId)
                .IsFixedLength();

            modelBuilder.Entity<StudentsDetail>()
                .Property(e => e.Contact)
                .IsFixedLength();

            modelBuilder.Entity<StudentsDetail>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<StudentsDetail>()
                .Property(e => e.StudentsCategory)
                .IsFixedLength();

            modelBuilder.Entity<StudentsDetail>()
                .HasMany(e => e.ExamScheduleStudents)
                .WithRequired(e => e.StudentsDetail)
                .WillCascadeOnDelete(false);
        }
    }
}
