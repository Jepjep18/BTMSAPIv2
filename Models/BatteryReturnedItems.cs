using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BTMSAPI.Models
{
    public class BatteryReturnedItems
    {
        public int Id { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Endorsedby { get; set; }
        public int? BatteryReleasedItemId { get; set; }

        [ForeignKey("BatteryReleasedItemId")]
        [JsonIgnore]
        public BatteryReleasedItems? BatteryReleasedItem { get; set; }
    }
}