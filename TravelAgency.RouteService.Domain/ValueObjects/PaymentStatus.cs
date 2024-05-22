namespace TravelAgency.RouteService.Domain.ValueObjects;
public sealed class PaymentStatus : SmartEnum<PaymentStatus> 
{
    public static readonly PaymentStatus WaitingForPayment = new PaymentStatus("Waiting for payment", 1);
    public static readonly PaymentStatus Paid = new PaymentStatus(nameof(Paid), 2);

    public PaymentStatus(string name, int value) : base(name, value)
    {
    }
}
