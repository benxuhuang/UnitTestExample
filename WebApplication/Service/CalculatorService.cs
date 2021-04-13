using System;
using WebApplication.DTO;

namespace WebApplication.Service
{
    public class CalculatorService : ICalculatorService
    {
        private ICompanyFactory _companyFactory;
        private IShipCompany _shipCompany;

        public CalculatorService(ICompanyFactory companyFactory, Func<string, IShipCompany> serviceResolver)
        {
            _companyFactory = companyFactory;
            _shipCompany = serviceResolver?.Invoke("postoffice");
        }

        public CalculatorService(ICompanyFactory companyFactory) : this(companyFactory, null) { }


        double ICalculatorService.GetFee(Shipment shipment)
        {
            return _companyFactory.GetShipCompanyInstance(shipment.ShipCompany)
                                  .CalculatorShipFee(shipment);
        }

        string ICalculatorService.GetCompanyName(string name)
        {
            return _companyFactory.GetShipCompanyInstance(name)
                                  .GetCompName();
        }

        public string GetDIMappingCompanyName()
        {
            return _shipCompany.CompName;
        }
    }
}
