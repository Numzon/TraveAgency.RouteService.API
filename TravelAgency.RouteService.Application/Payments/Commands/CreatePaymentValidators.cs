namespace TravelAgency.RouteService.Application.Payments.Commands;

public sealed class CreatePaymentRequestValidator : AbstractValidator<CreatePaymentRequest>
{
    public CreatePaymentRequestValidator()
    {
        RuleFor(x => x.Cost)
            .NotEmpty();

        RuleFor(x => x.RouteId)
            .NotEmpty();

        RuleFor(x => x.RouteApplicationId)
            .NotEmpty();
    }
}
