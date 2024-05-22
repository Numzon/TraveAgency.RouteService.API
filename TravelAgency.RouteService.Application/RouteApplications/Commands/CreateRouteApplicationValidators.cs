namespace TravelAgency.RouteService.Application.RouteApplications.Commands;
public sealed class CreateRouteApplicationRequestValidator : AbstractValidator<CreateRouteApplicationRequest>
{
	public CreateRouteApplicationRequestValidator()
	{
        RuleFor(x => x.Cost)
            .NotEmpty();

        RuleFor(x => x.VehicleId)
			.NotEmpty();

        RuleFor(x => x.DriverId)
            .NotEmpty();

        RuleFor(x => x.TravelAgencyId)
            .NotEmpty();

        RuleFor(x => x.RouteId)
            .NotEmpty();
    }
}