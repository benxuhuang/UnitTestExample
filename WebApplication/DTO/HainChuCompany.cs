namespace WebApplication.DTO
{
    public class HainChuCompany : IShipCompany
    {
        private string _compName = "新竹貨運";

        public string CompName
        {
            get { return _compName; }
            set { _compName = value; }
        }

        public double CalculatorShipFee(Shipment shipment)
        {
            return shipment.Length * shipment.Width * shipment.Height * 3;
        }

        public string GetCompName()
        {
            return CompName;
        }
    }
}
