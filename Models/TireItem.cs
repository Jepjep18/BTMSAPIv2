namespace BTMSAPI.Models
{
    public class TireItem
    {
        public int Id { get; set; }
        public DateTime? DateReceived { get; set; }
        public string? Receivedby { get; set; }
        public int? DrciNo { get; set; }
        public int? PoNo { get; set; }
        public string? Supplier { get; set; }
        public string? ItemCode { get; set; }
        public int? Quantity { get; set; }
        public string? Unitofmeasurement { get; set; }
        public string? Tiresize { get; set; }
        public string? Tirebrand { get; set; }
        public string? TireSerial { get; set; }
        public string? DebossedNo { get; set; }
        public string? Remarks { get; set; }
        public string? Status { get; set; }
        public string? TireType { get; set; }
        public string? NewSerialNo { get; set; }
        public string? ItemCategory { get; set; } = "Tire";
    }
}
