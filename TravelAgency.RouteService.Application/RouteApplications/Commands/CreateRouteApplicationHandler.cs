using TravelAgency.RouteService.Application.Common.Interfaces;

namespace TravelAgency.RouteService.Application.RouteApplications.Commands;
public sealed record CreateRouteApplicationResponse(int Id);

public sealed record CreateRouteApplicationRequest(decimal Cost, int VehicleId, int DriverId, int TravelAgencyId, int RouteId) : IRequest<Result<CreateRouteApplicationResponse>>;

public sealed class CreateRouteApplicationHandler : IRequestHandler<CreateRouteApplicationRequest, Result<CreateRouteApplicationResponse>>
{
    private readonly IRouteApplicationRepository _repository;

    public CreateRouteApplicationHandler(IRouteApplicationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CreateRouteApplicationResponse>> Handle(CreateRouteApplicationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.CreateAsync(request, cancellationToken);
            return Result.Success(response.Adapt<CreateRouteApplicationResponse>());
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return Result.Error(new ErrorList(new List<string> { ex.Message }));
        }
    }
}
