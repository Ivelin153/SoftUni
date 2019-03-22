namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer(Configuration.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            OnConfiguringStudents(builder);

            OnConfiguringCourses(builder);

            OnConfiguringResources(builder);

            OnConfiguringHomework(builder);

            OnConfiguringStudentCourses(builder);
        }

        private static void OnConfiguringStudentCourses(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(c => new { c.CourseId, c.StudentId });

            builder
                .Entity<StudentCourse>()
                .HasOne(s => s.Student)
                .WithMany(c => c.CourseEnrollments)
                .HasForeignKey(s => s.StudentId);

            builder
                .Entity<StudentCourse>()
                .HasOne(c => c.Course)
                .WithMany(s => s.StudentsEnrolled)
                .HasForeignKey(c => c.CourseId);
        }

        private void OnConfiguringStudents(ModelBuilder builder)
        {
            builder
                .Entity<Student>(entity =>
                {
                    entity
                        .HasKey(e => e.StudentId);

                    entity
                        .Property(e => e.Name)
                        .HasMaxLength(100)
                        .IsUnicode()
                        .IsRequired();

                    entity
                        .Property(e => e.PhoneNumber)
                        .HasColumnType("CHAR(10)");

                    entity
                        .HasMany(e => e.CourseEnrollments)
                        .WithOne(e => e.Student);

                });
        }

        private void OnConfiguringCourses(ModelBuilder builder)
        {
            builder
                .Entity<Course>(entity =>
                {
                    entity
                        .HasKey(c => c.CourseId);

                    entity
                        .Property(e => e.Name)
                        .HasMaxLength(80)
                        .IsUnicode()
                        .IsRequired();

                    entity
                        .Property(e => e.Description)
                        .IsUnicode();
                });
        }

        private void OnConfiguringResources(ModelBuilder builder)
        {
            builder
                .Entity<Resource>(entity =>
                {
                    entity
                        .HasKey(e => e.ResourceId);

                    entity
                        .Property(e => e.Name)
                        .HasMaxLength(50)
                        .IsUnicode()
                        .IsRequired();

                    entity
                        .Property(e => e.Url)
                        .IsRequired();

                    entity
                        .HasOne(e => e.Course)
                        .WithMany(c => c.Resources);
                });
        }

        private void OnConfiguringHomework(ModelBuilder builder)
        {
            builder
                .Entity<Homework>(entity =>
                {
                    entity
                        .HasKey(e => e.HomeworkId);

                    entity
                        .Property(e => e.Content)
                        .IsRequired();

                    entity
                        .HasOne(e => e.Student)
                        .WithMany(s => s.HomeworkSubmissions);

                    entity
                        .HasOne(e => e.Course)
                        .WithMany(c => c.HomeworkSubmissions);
                });
        }
    }
}
