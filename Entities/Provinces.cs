using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DefaultDotnetBackend.Entities
{
    [Table("provinces", Schema = "master")]
    [Index(nameof(ProvinceName), IsUnique = true)]
    public class Provinces
    {
        [Key]
        [Column("province_id", TypeName = "int")]
        public int ProvinceID { get; set; }

        [Required]
        [Column("province_name", TypeName = "varchar")]
        public required string ProvinceName { get; set; }

        [Required]
        [Column("country_id", TypeName = "int")]
        public required int CountryID { get; set; }

        [ForeignKey(nameof(CountryID))]
        public Countries? Country { get; set; }
    }
}