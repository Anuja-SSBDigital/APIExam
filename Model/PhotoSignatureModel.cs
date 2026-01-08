using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIExam.Model
{
    [Table("Student_Mst")]
    public class PhotoSignatureModel
    {
        [Key]
        public int Pk_StudentId { get; set; }
        public string? StudentPhotoPath { get; set; }
        public string? StudentSignaturePath { get; set; }
    }
}
