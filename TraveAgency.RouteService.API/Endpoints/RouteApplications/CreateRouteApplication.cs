using TravelAgency.RouteService.Application.RouteApplications.Commands;

namespace TraveAgency.RouteService.API.Endpoints.RouteApplications;

public sealed class CreateRouteApplication : EndpointBaseAsync.WithRequest<CreateRouteApplicationRequest>.WithResult<Result<CreateRouteApplicationResponse>>
{
    private readonly ISender _sender;

    public CreateRouteApplication(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("api/route-applications")]
    [SwaggerOperation(Summary = "Creates route application", Tags = new[] { "Route Application" })]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public override async Task<Result<CreateRouteApplicationResponse>> HandleAsync([FromBody] CreateRouteApplicationRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(request, cancellationToken);

        return result;
    }
}
