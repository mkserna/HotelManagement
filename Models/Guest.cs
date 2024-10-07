using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

[Table("guests")]
public class Guest
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("first_name")]
    public required string FirstName { get; set; }
    [Column("last_name")]
    public required string LastName { get; set; }
    [Column("email")]
    public required string Email { get; set; }
    [Column("phone_number")]
    public required string PhoneNumber { get; set; }    
    [Column("birthdate")]
    public DateOnly BirthDate { get; set; }

    internal bool Any()
    {
        throw new NotImplementedException();
    }
}
