using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Group2_Sis3.Models
{
    [Table("Student")]
    public class Studenti
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Emri kerkohet")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Mbiemri kerkohet")]
        public string Mbiemri { get; set; }
        [Required(ErrorMessage = "Komuna kerkohet")]
        public int KomunaId { get; set; }
        [ValidateNever]
        [ForeignKey("KomunaId")]
        public Komuna Komuna { get; set; }
    }
}
