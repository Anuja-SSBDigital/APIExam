using APIExam.Data;
using APIExam.Model.DTOs;
using APIExam.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Services.Services
{
    public class PhotoSignService : IPhotoSignService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PhotoSignService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<string> UploadPhotoSignatureAsync(PhotoSignDTO dto)
        {
            if (dto.StudentPhotoPath == null || dto.StudentSignaturePath == null)
                throw new Exception("Photo and Signature are required");

            var student = await _context.Students
                .FirstOrDefaultAsync(x => x.Pk_StudentId == dto.Pk_StudentId);

            if (student == null)
                throw new Exception("Student not found");

            student.StudentPhotoPath = await SaveFile(dto.StudentPhotoPath, "Photos");
            student.StudentSignaturePath = await SaveFile(dto.StudentSignaturePath, "Signatures");

            await _context.SaveChangesAsync();

            return "Photo & Signature uploaded successfully";
        }

        private async Task<string> SaveFile(IFormFile file, string folderName)
        {
            string root = _env.WebRootPath ?? throw new Exception("wwwroot not found");

            string path = Path.Combine(root, "uploads", folderName);
            Directory.CreateDirectory(path);

            string ext = Path.GetExtension(file.FileName).ToLower();
            if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(ext))
                throw new Exception("Only JPG, JPEG, PNG allowed");

            if (file.Length > 1024 * 1024)   
                throw new Exception("File must be under 1MB");

            string fileName = $"{Guid.NewGuid()}{ext}";
            string fullPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/uploads/{folderName}/{fileName}";
        }
    }
}
