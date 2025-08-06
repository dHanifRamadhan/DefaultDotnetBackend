using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DefaultDotnetBackend.Enums;
using Microsoft.EntityFrameworkCore;

namespace DefaultDotnetBackend.Entities
{
    [Table("settings", Schema = "master")]
    [Index(nameof(SettingName), IsUnique = true)]
    public class Settings
    {
        [Key]
        [StringLength(50)]
        [Column("setting_id", TypeName = "varchar")]
        public required string SettingID { get; set; }

        [Required]
        [Column("setting_name", TypeName = "varchar")]
        public required string SettingName { get; set; }

        [Required]
        [Column("setting_type", TypeName = "varchar")]
        public required string SettingType { get; set; }

        [Required]
        [Column("setting_value", TypeName = "varchar")]
        public required string SettingValue { get; set; }

        [Required]
        [Column("setting_description", TypeName = "varchar")]
        public required string SettingDesctiption { get; set; }

        [AllowNull]
        [EnumDataType(typeof(SettingReff))]
        [Column("setting_reff", TypeName = "string")]
        public string? SettingReff { get; set; }

        [AllowNull]
        [Column("setting_reff_id", TypeName = "varchar")]
        public string? SettingReffID { get; set; }
    }
}