using WebApplication.DTO;

namespace WebApplication.Service
{
    public interface ICompanyFactory
    {
        IShipCompany GetShipCompanyInstance(string name);
    }
}
