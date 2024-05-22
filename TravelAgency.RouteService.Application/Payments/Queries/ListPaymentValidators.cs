namespace TravelAgency.RouteService.Application.Payments.Queries;
public sealed class ListPaymentValidators : AbstractValidator<ListPaymentRequest>
{
	public ListPaymentValidators()
	{
		RuleFor(x => x.From)
			.NotEmpty();

		RuleFor(x => x.To)
			.NotEmpty();
	}
}
