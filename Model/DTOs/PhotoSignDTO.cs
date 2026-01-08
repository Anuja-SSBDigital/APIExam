using System.ComponentModel.DataAnnotations.Schema;

namespace APIExam.Model.DTOs
{
    
    public class PhotoSignDTO
    {
        public int Pk_StudentId { get; set; }
        public IFormFile? StudentPhotoPath { get; set; }
        public IFormFile? StudentSignaturePath { get; set; }
    }
}
