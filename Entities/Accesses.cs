using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DefaultDotnetBackend.Enums;

namespace DefaultDotnetBackend.Entities
{
    [Table("accesses", Schema = "master")]
    public class Accesses
    {
        [Key]
        [StringLength(50)]
        [Column("access_id", TypeName = "varchar")]
        public required string AccessID { get; set; }

        [Required]
        [EnumDataType(typeof(PageCode))]
        [Column("page_code", TypeName = "varchar")]
        public required string PageCode { get; set; }

        [Required]
        [Column("access_type", TypeName = "varchar")]
        public required string AccessType { get; set; }

        [Required]
        [StringLength(50)]
        [Column("role_id", TypeName = "varchar")]
        public required string RoleID { get; set; }

        [ForeignKey(nameof(RoleID))]
        public Roles? Role { get; set; }
    }
}