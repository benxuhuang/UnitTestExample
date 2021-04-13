using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.DTO;
using WebApplication.Service;

namespace WebApplication.Controllers.Tests
{
    [TestClass()]
    public class ShipmentControllerTests
    {

        [TestMethod()]
        public void Shipment_Fee_Calculator_Test()
        {
            ICalculatorService target = new CalculatorService(new CompanyFactory());

            var shipment = new Shipment()
            {
                ShipCompany = "blackCat",
                Length = 10,
                Width = 20,
                Height = 5
            };

            var expected = 1000;
            var actual = target.GetFee(shipment);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Get_Company_Name_Test()
        {
            ICalculatorService target = new CalculatorService(new CompanyFactory());
            var expected = "黑貓";
            var actual = target.GetCompanyName("blackCat");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Get_Multi_Instance_DI_Mapping_Test()
        {
            //Func<string, IShipCompany> serviceResolver = FuncAction;
            //ICalculatorService target = new CalculatorService(new CompanyFactory(), FuncAction);

            ICalculatorService target = new CalculatorService(new CompanyFactory(), (name) =>
            {
                return name switch
                {
                    "blackcat" => new BlackCatCompany(),
                    "postoffice" => new PostOfficeCompany(),
                    "hainchu" => new HainChuCompany(),
                    _ => new BlackCatCompany(),
                };
            });

            var expected = "郵局";
            var actual = target.GetDIMappingCompanyName();
            Assert.AreEqual(expected, actual);
        }

        //public static IShipCompany FuncAction(string name)
        //{
        //    switch (name)
        //    {
        //        case "blackcat":
        //            return new BlackCatCompany();
        //        case "postoffice":
        //            return new PostOfficeCompany();
        //        case "hainchu":
        //            return new HainChuCompany();
        //        default:
        //            return new BlackCatCompany();
        //    }
        //}
    }
}
