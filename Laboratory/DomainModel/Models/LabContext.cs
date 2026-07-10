using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DomainModel.Models
{
    public partial class LabContext : DbContext
    {
        public LabContext()
            : base("name=LabContext")
        {
        }

        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<ResponseType> ResponseType { get; set; }
        public virtual DbSet<SampleType> SampleType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestAcceptionHeader> TestAcceptionHeader { get; set; }
        public virtual DbSet<TestAcceptionItem> TestAcceptionItem { get; set; }
        public virtual DbSet<TestCategory> TestCategory { get; set; }
        public virtual DbSet<TestMethod> TestMethod { get; set; }
        public virtual DbSet<TestRange> TestRange { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.TestAcceptionHeader)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LoginHistory)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TestAcceptionHeader)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.RegistrationEmployeeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.TestAcceptionHeader)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SampleType>()
                .HasMany(e => e.Test)
                .WithRequired(e => e.SampleType)
                .HasForeignKey(e => e.SamplyeTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestAcceptionItem)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestRange)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestAcceptionHeader>()
                .HasMany(e => e.TestAcceptionItem)
                .WithRequired(e => e.TestAcceptionHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestCategory>()
                .HasMany(e => e.Test)
                .WithRequired(e => e.TestCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestMethod>()
                .HasMany(e => e.Test)
                .WithRequired(e => e.TestMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.Test)
                .WithRequired(e => e.Unit)
                .WillCascadeOnDelete(false);
        }
    }
}
