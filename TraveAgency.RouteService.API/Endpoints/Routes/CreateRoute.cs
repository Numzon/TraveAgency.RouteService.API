using TravelAgency.RouteService.Application.Routes.Commands.CreateRoute;

namespace TraveAgency.RouteService.API.Endpoints.Routes;

public sealed class CreateRoute : EndpointBaseAsync.WithRequest<CreateRouteRequest>.WithResult<Result<CreateRouteResponse>>
{
    private readonly ISender _sender;

    public CreateRoute(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("api/routes")]
    [SwaggerOperation(Summary = "Creates routes", Tags = new[] { "Routes" })]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public override async Task<Result<CreateRouteResponse>> HandleAsync([FromBody] CreateRouteRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(request, cancellationToken);

        return result;
    }
}
