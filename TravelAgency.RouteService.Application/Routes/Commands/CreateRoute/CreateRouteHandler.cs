using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Application.Common.Models;

namespace TravelAgency.RouteService.Application.Routes.Commands.CreateRoute;

public sealed record CreateRouteResponse(int Id);

public sealed record CreateRouteRequest(int ClientId, IEnumerable<CreatePassagerDto> Passagers) : IRequest<Result<CreateRouteResponse>>;

public sealed class CreateRouteHandler : IRequestHandler<CreateRouteRequest, Result<CreateRouteResponse>>
{
    private readonly IRouteRepository _repository;

    public CreateRouteHandler(IRouteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CreateRouteResponse>> Handle(CreateRouteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.CreateAsync(request, cancellationToken);
            return Result.Success(response.Adapt<CreateRouteResponse>());
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return Result.Error(new ErrorList(new List<string> { ex.Message }));
        }
    }
}
