namespace BTMSAPI.Models
{
    public class TireDisposedItems
    {
        public int Id { get; set; }
        public DateTime DisposalDate { get; set; }
        public string EndorsedBy { get; set; }
        public string DisposalType { get; set; }
        public string TireReturnIds { get; set; }
        public string DisposalStatus { get; set; }
    }
}
