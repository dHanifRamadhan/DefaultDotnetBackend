using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DefaultDotnetBackend.Enums;
using Microsoft.EntityFrameworkCore;

namespace DefaultDotnetBackend.Entities
{
    [Table("users", Schema = "master")]
    [Index(nameof(UserID), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    public class Users
    {
        [Key]
        [Required]
        [StringLength(50)]
        [Column("user_id", TypeName = "varchar")]
        public required string UserID { get; set; }

        [Required]
        [StringLength(100)]
        [Column("username", TypeName = "varchar")]
        public required string Username { get; set; }

        [Required]
        [StringLength(255)]
        [Column("full_name", TypeName = "varchar")]
        public required string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(320)]
        [Column("email", TypeName = "varchar")]
        public required string Email { get; set; }

        [Required]
        [Phone]
        [Column("phone", TypeName = "varchar")]
        public required string Phone { get; set; }

        [Required]
        [Column("address", TypeName = "text")]
        public required string Address { get; set; }

        [Required]
        [Column("country_id", TypeName = "int")]
        public required int CountryID { get; set; }

        [ForeignKey(nameof(CountryID))]
        public Countries? Country { get; set; }

        [Required]
        [Column("province_id", TypeName = "int")]
        public required int ProvinceID { get; set; }

        [ForeignKey(nameof(ProvinceID))]
        public Provinces? Province { get; set; }

        [Required]
        [Column("city_id", TypeName = "int")]
        public required int CityID { get; set; }

        [ForeignKey(nameof(CityID))]
        public Cities? City { get; set; }

        [Required]
        [Column("district_id", TypeName = "int")]
        public required int DistrictID { get; set; }

        [ForeignKey(nameof(DistrictID))]
        public Districts? District { get; set; }

        [Required]
        [EnumDataType(typeof(StatusUsers))]
        [Column("status", TypeName = "string")]
        public required string Status { get; set; }

        [Required]
        [Column("role_id", TypeName = "string")]
        public required string RoleID { get; set; }

        [ForeignKey(nameof(RoleID))]
        public Roles? Role { get; set; }

        [AllowNull]
        [Column("last_login", TypeName = "timestamptz")]
        public DateTime? LastLogin { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_date", TypeName = "timestamptz")]
        public DateTime CreatedDate { get; set; }

        [AllowNull]
        [Column("updated_date", TypeName = "timestamptz")]
        public DateTime? UpdatedDate { get; set; }

        [AllowNull]
        [Column("updated_by", TypeName = "timestamptz")]
        public int? UpdatedBy { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public Users? Updated { get; set; }

        [AllowNull]
        [Column("deleted_date", TypeName = "timestamptz")]
        public DateTime? DeletedDate { get; set; }

        [AllowNull]
        [Column("deleted_by", TypeName = "timestamptz")]
        public int? DeletedBy { get; set; }

        [ForeignKey(nameof(DeletedBy))]
        public Users? Deleted { get; set; }
    }
}