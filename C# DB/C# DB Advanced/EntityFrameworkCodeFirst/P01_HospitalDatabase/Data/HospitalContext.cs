namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(Configuration.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigurePatientEntity(builder);

            ConfigureVisitationEntity(builder);

            ConfigureDiagnoseEntity(builder);

            ConfigureMedicamentEntity(builder);

            ConfigureMedicamentPatientEntity(builder);

            ConfigureDoctorEntity(builder);
        }

        private void ConfigureDoctorEntity(ModelBuilder builder)
        {
            builder
                .Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            builder
               .Entity<Doctor>()
               .HasMany(d => d.Visitations)
               .WithOne(d => d.Doctor);

            builder
                .Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder
               .Entity<Doctor>()
               .Property(d => d.Specialty)
               .HasMaxLength(100)
               .IsUnicode()
               .IsRequired();
        }

        private void ConfigureMedicamentPatientEntity(ModelBuilder builder)
        {
            builder
                .Entity<PatientMedicament>()
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            builder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);

            builder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);
        }

        private void ConfigureMedicamentEntity(ModelBuilder builder)
        {
            builder
                .Entity<Medicament>()
                .HasKey(m => m.MedicamentId);

            builder
                .Entity<Medicament>()
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
        }

        private void ConfigureDiagnoseEntity(ModelBuilder builder)
        {
            builder
                .Entity<Diagnose>()
                .HasKey(d => d.DiagnoseId);

            builder
                .Entity<Diagnose>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Entity<Diagnose>()
                .Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void ConfigureVisitationEntity(ModelBuilder builder)
        {
            builder
                .Entity<Visitation>()
                .HasKey(v => v.VisitationId);

            builder
                .Entity<Visitation>()
                .Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void ConfigurePatientEntity(ModelBuilder builder)
        {
            builder
                .Entity<Patient>()
                .HasKey(p => p.PatientId);

            builder
                .Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Patient);

            builder
                .Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient);

            builder
                .Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
              .Entity<Patient>()
              .Property(p => p.LastName)
              .HasMaxLength(50)
              .IsUnicode()
              .IsRequired();

            builder
              .Entity<Patient>()
              .Property(p => p.Address)
              .HasMaxLength(250)
              .IsUnicode()
              .IsRequired();

            builder
              .Entity<Patient>()
              .Property(p => p.Email)
              .HasMaxLength(80);
        }
    }
}
