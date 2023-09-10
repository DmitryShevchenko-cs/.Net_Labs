using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class AtmService : IAtmService
{
    private readonly BankDBContext _context = new BankDBContext();

    public async Task<ATM?> GetByIdAsync(int id)
    {
        return await _context.ATMs.Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        const double earthRadius = 6371000;

        double lat1Rad = ToRadians(lat1);
        double lon1Rad = ToRadians(lon1);
        double lat2Rad = ToRadians(lat2);
        double lon2Rad = ToRadians(lon2);

        
        double dLat = lat2Rad - lat1Rad;
        double dLon = lon2Rad - lon1Rad;
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        
        double distance = earthRadius * c;
        return distance;
    }

    private double ToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }
    
    public async Task<List<ATM>> FindNearestATMs(int atmId, int count)
    {
        var atm = await _context.ATMs.Where(i => i.Id == atmId).FirstOrDefaultAsync();
        
        var nearestAtMs = _context.ATMs
            .AsEnumerable()
            .OrderBy(i => CalculateDistance(atm!.Latitude, atm.Longitude, i.Latitude, i.Longitude))
            .Take(count) 
            .ToList();
        
        return nearestAtMs;
    }
    
    public string ToString(List<ATM> atms)
    {
        string atmString = "";
        foreach (var atm in atms!)
        {
            atmString +=$"{atm.ATMNumber}, {atm.City}, {atm.Address}\n";
        }
        return atmString;
    }
}