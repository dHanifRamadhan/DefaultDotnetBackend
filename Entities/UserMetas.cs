using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DefaultDotnetBackend.Enums;

namespace DefaultDotnetBackend.Entities
{
    // TODO : Table ini akan di tampilkan list/detail user
    [Table("user_metas", Schema = "master")]
    public class UserMetas
    {
        [Key]
        [Required]
        [StringLength(50)]
        [Column("user_meta_id", TypeName = "varchar")]
        public required string UserMetaID { get; set; }

        [Required]
        [EnumDataType(typeof(MetaTypeUser))]
        [Column("user_meta_type", TypeName = "varchar")]
        public required string UserMetaType { get; set; }

        [Required]
        [Column("user_meta_value", TypeName = "text")]
        public required string UserMetaValue { get; set; }

        [Required]
        [Column("user_id", TypeName = "string")]
        public required string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users? User { get; set; }
    }
}