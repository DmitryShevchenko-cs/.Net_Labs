namespace BankLibrary.Services.Interfaces;

public interface IAtmService : IBaseService<ATM>
{
    public double CalculateDistance(double lat1, double lon1, double lat2, double lon2);

    public Task<List<ATM>> FindNearestATMs(int atmId, int count);
}