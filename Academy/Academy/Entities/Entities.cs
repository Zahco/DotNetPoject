namespace Academy.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }

        public virtual DbSet<Academies> Academies { get; set; }
        public virtual DbSet<Classrooms> Classrooms { get; set; }
        public virtual DbSet<Cycles> Cycles { get; set; }
        public virtual DbSet<Establishments> Establishments { get; set; }
        public virtual DbSet<Evaluations> Evaluations { get; set; }
        public virtual DbSet<Levels> Levels { get; set; }
        public virtual DbSet<Periods> Periods { get; set; }
        public virtual DbSet<Pupils> Pupils { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Tutors> Tutors { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Years> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academies>()
                .HasMany(e => e.Establishments)
                .WithRequired(e => e.Academies)
                .HasForeignKey(e => e.Academie_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classrooms>()
                .HasMany(e => e.Evaluations)
                .WithRequired(e => e.Classrooms)
                .HasForeignKey(e => e.Classroom_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classrooms>()
                .HasMany(e => e.Pupils)
                .WithRequired(e => e.Classrooms)
                .HasForeignKey(e => e.Classroom_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cycles>()
                .HasMany(e => e.Levels)
                .WithRequired(e => e.Cycles)
                .HasForeignKey(e => e.Cycle_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Establishments>()
                .HasMany(e => e.Classrooms)
                .WithRequired(e => e.Establishments)
                .HasForeignKey(e => e.Establishment_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evaluations>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Evaluations)
                .HasForeignKey(e => e.Evaluation_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Levels>()
                .HasMany(e => e.Pupils)
                .WithRequired(e => e.Levels)
                .HasForeignKey(e => e.Level_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Periods>()
                .HasMany(e => e.Evaluations)
                .WithRequired(e => e.Periods)
                .HasForeignKey(e => e.Period_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pupils>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Pupils)
                .HasForeignKey(e => e.Pupil_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tutors>()
                .HasMany(e => e.Pupils)
                .WithRequired(e => e.Tutors)
                .HasForeignKey(e => e.Tutor_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Classrooms)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Establishments)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Evaluations)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Years>()
                .HasMany(e => e.Classrooms)
                .WithRequired(e => e.Years)
                .HasForeignKey(e => e.Year_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Years>()
                .HasMany(e => e.Periods)
                .WithRequired(e => e.Years)
                .HasForeignKey(e => e.Year_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
