namespace WebApplication.DTO
{
    public class BlackCatCompany : IShipCompany
    {
        private string _compName = "黑貓";

        public string CompName
        {
            get { return _compName; }
            set { _compName = value; }
        }

        public double CalculatorShipFee(Shipment shipment)
        {
            return shipment.Length * shipment.Width * shipment.Height * 1;
        }

        public string GetCompName()
        {
            return CompName;
        }
    }
}
