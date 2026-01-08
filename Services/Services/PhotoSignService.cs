using APIExam.Data;
using APIExam.Model.DTOs;
using APIExam.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Services.Services
{
    public class PhotoSignService: IPhotoSignService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PhotoSignService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<string> UploadPhotoSignatureAsycn(PhotoSignDTO photoSignDTO)
        {
            if (photoSignDTO.StudentPhotoPath == null || photoSignDTO.StudentSignaturePath == null)
                throw new Exception("Photo and Signature are required");

            var student = await _context.PhotoSignatureModels
                .FirstOrDefaultAsync(x => x.Pk_StudentId == photoSignDTO.Pk_StudentId);

            if (student == null)
                throw new Exception("Student not found");

            // Save files
            string photoPath = await SaveFile(photoSignDTO.StudentPhotoPath, "Photos");
            string signaturePath = await SaveFile(photoSignDTO.StudentSignaturePath, "Signatures");

            // Assign paths to entity
            student.StudentPhotoPath = photoPath;
            student.StudentSignaturePath = signaturePath;

            await _context.SaveChangesAsync();

            return "Photo & Signature uploaded successfully";
        }


        private async Task<string> SaveFile(IFormFile file, string folderName)
        {
            string webRoot = _env.WebRootPath;

            if (string.IsNullOrEmpty(webRoot))
                throw new Exception("wwwroot folder not found.");

            string folderPath = Path.Combine(webRoot, "uploads", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string extension = Path.GetExtension(file.FileName).ToLower();

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                throw new Exception("Only JPG/JPEG/PNG files allowed.");

            if (file.Length > 1 * 1024 * 1024)
                throw new Exception("File size must be under 1 MB.");

            string fileName = Guid.NewGuid() + extension;
            string fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{folderName}/{fileName}";
        }
    }
}
