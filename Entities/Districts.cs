using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DefaultDotnetBackend.Entities
{
    [Table("districts", Schema = "master")]
    [Index(nameof(DistrictName), IsUnique = true)]
    public class Districts
    {
        [Key]
        [Column("district_id", TypeName = "int")]
        public int DistrictID { get; set; }

        [Required]
        [Column("district_name", TypeName = "string")]
        public required string DistrictName { get; set; }

        [Required]
        [Column("city_id", TypeName = "int")]
        public int CityID { get; set; }

        [ForeignKey(nameof(CityID))]
        public Cities? City { get; set; }
    }
}