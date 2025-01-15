using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BTMSAPI.Models
{
    public class TireReturnedItems
    {
        public int Id { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public string? EndorsedBy { get; set; }

        public string? Purpose { get; set; }
        public int? TireReleasedId { get; set; }


        [ForeignKey("TireReleasedId")]
        [JsonIgnore]
        public TireReleasedItems? TireReleasedItems { get; set; }

    }
}
