using Think41.BaggageAPI.DTOs;

namespace Think41.BaggageAPI.Services
{
    public interface IBagService
    {
        Task<BagScanDto?> GetLastLocationAsync(string bagTagId);
        Task<IEnumerable<BagScanDto>> GetEnrouteBagsAsync(string destinationGate, int sinceMinutes);
        Task<IEnumerable<RankedGateDto>> GetGateRankingsAsync(int sinceMinutes);
    }
}
