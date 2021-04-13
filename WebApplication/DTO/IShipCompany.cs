namespace WebApplication.DTO
{
    public interface IShipCompany
    {
        string CompName { get; set; }

        double CalculatorShipFee(Shipment shipment);

        string GetCompName();
    }
}
