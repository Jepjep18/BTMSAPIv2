using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BTMSAPI.Models
{
    public class BatteryReleasedItems
    {
        public int Id { get; set; }
        public string? BusinessUnit { get; set; }
        public string? Imjno { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? ReleasedReceivedby { get; set; }
        public string? UserplateNo { get; set; }
        public string? Remarks { get; set; }
        public int? BatteryItemId { get; set; }
        public string? OldSnDebossedNo { get; set; }
        public DateTime ReleasedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("BatteryItemId")]
        [JsonIgnore]
        public BatteryItem? BatteryItem { get; set; }
    }
}