using TravelAgency.RouteService.Application.Common.Models;

namespace TravelAgency.RouteService.Application.Routes.Commands.CreateRoute;
public sealed class CreateRouteRequestValidator : AbstractValidator<CreateRouteRequest>
{
    public CreateRouteRequestValidator()
    {
        RuleFor(x => x.ClientId)
            .NotEmpty();

        RuleFor(x => x.Passagers)
            .NotEmpty();
    }
}

public sealed class CreatePassagerDtoValidator : AbstractValidator<CreatePassagerDto>
{
    public CreatePassagerDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.Phone)
            .NotEmpty();
    }
}