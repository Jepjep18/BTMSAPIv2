using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BTMSAPI.Models
{
    public class TireReleasedItems
    {
        public int Id { get; set; }
        public string? BusinessUnit { get; set; }
        public string? Imjno { get; set; }
        public string? Driver { get; set; }
        public string? PlateNo { get; set; }
        public string? Abfiserialno { get; set; }
        public string? Remarks { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Receivedby { get; set; }
        public int? TireItemId { get; set; }
        public string? OldSnDebossedNo { get; set; }

        [ForeignKey("TireId")]
        [JsonIgnore]
        public TireItem? TireItem { get; set; }
    }
}
