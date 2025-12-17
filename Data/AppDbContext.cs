using APIExam.Model;
using APIExam.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<LoginResultModel> LoginResult { get; set; }
        public DbSet<DonwloadExamformModel> DonwloadExamformModelesult { get; set; }
        public DbSet<Student_Mst> Student_Mst { get; set; }
        public DbSet<DownloadExamFormResponse> DownloadExamFormResponse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the LoginResultModel entity
            modelBuilder.Entity<LoginResultModel>().HasKey(u => u.Id);
            modelBuilder.Entity<DonwloadExamformModel>().HasKey(i=> i.CollegeId);
            modelBuilder.Entity<Student_Mst>().HasKey(i=> i.StudentID);
            modelBuilder.Entity<DownloadExamFormResponse>().HasNoKey();
        }
    }
}
