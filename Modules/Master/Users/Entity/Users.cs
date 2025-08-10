using System.ComponentModel.DataAnnotations.Schema;

namespace DefaultDotnetBackend.Entities
{
    [Table("users")]
    public class Users
    {
        public required string UserId { get; set; }
    }
}