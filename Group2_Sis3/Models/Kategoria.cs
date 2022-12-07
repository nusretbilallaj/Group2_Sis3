using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Group2_Sis3.Models
{
    [Table("Kategoria")]
    public class Kategoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Emri kerkohet")]
        public string Emri { get; set; }
       
    }
}
