namespace Think41.BaggageAPI.Models
{
    public class BagScan
    {
        public int Id { get; set; }
        public string BagTagId { get; set; }
        public string DestinationGate { get; set; }
        public string LocationScanned { get; set; }
        public DateTime ScanTimestamp { get; set; }
    }
}
