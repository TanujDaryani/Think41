namespace Think41.BaggageAPI.DTOs
{
    public class BagScanDto
    {
        public string BagTagId { get; set; }
        public string LastLocation { get; set; }
        public DateTime LastScanAt { get; set; }
    }
}
