using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DB.Entities
{
    [Table(name: "own_owner")]
    public class OwnerEntity : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Required]
        [StringLength(15)]
        public string Phone { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Password { get; set; } = null!;
    }
}