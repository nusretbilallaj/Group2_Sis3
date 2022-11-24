using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Group2_Sis3.Models
{
    [Table("Profesor")]
    public class Profesori
    {
        public int Id { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }

    }
}
