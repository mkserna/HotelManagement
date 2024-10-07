using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

[Table("rooms")]
public class Room
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("room_number")]
    public required string RoomNumber { get; set; }

    [Column("room_type_id")]
    public int RoomTypeId { get; set; }

    [Column("price_per_night")]
    public double PricePerNight { get; set; }

    [Column("availability")]
    public bool Availability { get; set; }

    [Column("max_occupancy_person")]
    public byte MaxOccupancyPerson { get; set; }

    [ForeignKey("RoomTypeId")]
    public RoomType RoomType { get; set; }
}
