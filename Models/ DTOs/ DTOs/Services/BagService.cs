using Microsoft.EntityFrameworkCore;
using Think41.BaggageAPI.DTOs;
using Think41.BaggageAPI.Models;

namespace Think41.BaggageAPI.Services
{
    public class BagService : IBagService
    {
        private readonly Think41DbContext _context;

        public BagService(Think41DbContext context)
        {
            _context = context;
        }

        public async Task<BagScanDto?> GetLastLocationAsync(string bagTagId)
        {
            var result = await _context.BagScans
                .Where(b => EF.Functions.Collate(b.BagTagId, "SQL_Latin1_General_CP1_CS_AS") == bagTagId)
                .OrderByDescending(b => b.ScanTimestamp)
                .FirstOrDefaultAsync();

            return result == null ? null : new BagScanDto
            {
                BagTagId = result.BagTagId,
                LastLocation = result.LocationScanned,
                LastScanAt = result.ScanTimestamp
            };
        }

        public async Task<IEnumerable<BagScanDto>> GetEnrouteBagsAsync(string destinationGate, int sinceMinutes)
        {
            var since = DateTime.UtcNow.AddMinutes(-sinceMinutes);

            var recent = await _context.BagScans
                .Where(b => b.DestinationGate == destinationGate && b.ScanTimestamp >= since)
                .GroupBy(b => b.BagTagId)
                .Select(g => g.OrderByDescending(x => x.ScanTimestamp).First())
                .ToListAsync();

            return recent.Select(x => new BagScanDto
            {
                BagTagId = x.BagTagId,
                LastLocation = x.LocationScanned,
                LastScanAt = x.ScanTimestamp
            });
        }

        public async Task<IEnumerable<RankedGateDto>> GetGateRankingsAsync(int sinceMinutes)
        {
            var sinceTime = DateTime.UtcNow.AddMinutes(-sinceMinutes);

            var gateCounts = await _context.BagScans
                .Where(b => b.ScanTimestamp >= sinceTime)
                .GroupBy(b => new { b.DestinationGate, b.BagTagId })
                .Select(g => g.Key)
                .GroupBy(x => x.DestinationGate)
                .Select(g => new
                {
                    DestinationGate = g.Key,
                    UniqueBagCount = g.Count()
                })
                .OrderByDescending(x => x.UniqueBagCount)
                .ToListAsync();

            return gateCounts.Select((g, i) => new RankedGateDto
            {
                Rank = i + 1,
                DestinationGate = g.DestinationGate,
                UniqueBagCount = g.UniqueBagCount
            });
        }
    }
}
