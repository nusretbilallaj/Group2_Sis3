using System.ComponentModel.DataAnnotations.Schema;

namespace Group2_Sis3.Models
{
    [Table("Komuna")]
    public class Komuna
    {
        public int Id { get; set; }
        public string Emri { get; set; }
    }
}
