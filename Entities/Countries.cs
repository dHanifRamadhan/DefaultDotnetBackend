using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DefaultDotnetBackend.Entities
{
    [Table("countries", Schema = "master")]
    [Index(nameof(CountryName), IsUnique = true)]
    public class Countries
    {
        [Key]
        [Column("country_id", TypeName = "int")]
        public int CountryID { get; set; }

        [Required]
        [Column("country_name", TypeName = "varchar")]
        public required string CountryName { get; set; }

        [Required]
        [Column("numeric_code", TypeName = "int")]
        public int NumericCode { get; set; }

        [Required]
        [Column("phone_code", TypeName = "varchar")]
        public required string PhoneCode { get; set; }

        [Required]
        [Column("flag_url", TypeName = "text")]
        public required string FlagURL { get; set; }

        [Required]
        [Column("currency_code", TypeName = "varchar")]
        public required string CurrencyCode { get; set; }

        [Required]
        [Column("currency_name", TypeName = "varchar")]
        public required string CurrencyName { get; set; }

        [Required]
        [Column("timezone", TypeName = "varchar")]
        public required string TimeZone { get; set; }

        [Required]
        [Column("is_active", TypeName = "bool")]
        public bool IsActive { get; set; }
    }
}