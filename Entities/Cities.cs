using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DefaultDotnetBackend.Entities
{
    [Table("cities", Schema = "master")]
    [Index(nameof(CityName), IsUnique = true)]
    public class Cities
    {
        [Key]
        [Column("city_id", TypeName = "int")]
        public int CityID { get; set; }

        [Required]
        [Column("city_name", TypeName = "varchar")]
        public required string CityName { get; set; }

        [Required]
        [Column("province_id", TypeName = "int")]
        public int ProvinceID { get; set; }

        [ForeignKey(nameof(ProvinceID))]
        public Provinces? Province { get; set; }
    }
}