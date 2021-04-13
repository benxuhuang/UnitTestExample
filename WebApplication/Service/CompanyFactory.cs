using System;
using WebApplication.DTO;

namespace WebApplication.Service
{
    public class CompanyFactory : ICompanyFactory
    {
        IShipCompany ICompanyFactory.GetShipCompanyInstance(string name)
        {
            return name switch
            {
                "blackCat" => new BlackCatCompany(),
                "postOffice" => new PostOfficeCompany(),
                "hainChu" => new HainChuCompany(),
                _ => throw new NullReferenceException(),
            };
        }
    }
}
