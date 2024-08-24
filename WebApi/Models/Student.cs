using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Base;

namespace WebApi.Models
{
    [Table("student")]
    [Index(nameof(RA), IsUnique = true)]
    public class Student : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("email")]
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("cpf")]
        [Required]
        [StringLength(20)]
        public string CPF {  get; set; }
        
        [Column("ra")]
        [Required]
        [StringLength(20)]
        
        public string RA { get; set; }
    }
}
