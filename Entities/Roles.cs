using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DefaultDotnetBackend.Entities
{
    [Table("roles", Schema = "master")]
    [Index(nameof(RoleName), IsUnique = true)]
    public class Roles
    {
        [Key]
        [StringLength(50)]
        [Column("role_id", TypeName = "varchar")]
        public required string RoleID { get; set; }

        [Required]
        [Column("role_name", TypeName = "varchar")]
        public required string RoleName { get; set; }

        [AllowNull]
        public ICollection<Accesses>? Accesses { get; set; }
    }
}