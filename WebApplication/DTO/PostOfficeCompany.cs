namespace WebApplication.DTO
{
    public class PostOfficeCompany : IShipCompany
    {
        private string _compName = "郵局";

        public string CompName
        {
            get { return _compName; }
            set { _compName = value; }
        }

        public double CalculatorShipFee(Shipment shipment)
        {
            return shipment.Length * shipment.Width * shipment.Height * 2;
        }

        public string GetCompName()
        {
            return CompName;
        }
    }
}
