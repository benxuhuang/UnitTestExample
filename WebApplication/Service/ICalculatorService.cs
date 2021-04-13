using WebApplication.DTO;

namespace WebApplication.Service
{
    public interface ICalculatorService
    {
        double GetFee(Shipment shipment);
        string GetCompanyName(string name);
        string GetDIMappingCompanyName();
    }
}
