using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Domain.Events;

namespace TravelAgency.RouteService.Application.Payments.Commands;
public sealed record CreatePaymentResponse(int Id);

public sealed record CreatePaymentRequest(decimal Cost, int RouteApplicationId, int RouteId) : IRequest<Result<CreatePaymentResponse>>;

public sealed class CreatePaymentHandler : IRequestHandler<CreatePaymentRequest, Result<CreatePaymentResponse>>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPublisher _publisher;

    public CreatePaymentHandler(IPaymentRepository paymentRepository, IPublisher publisher)
    {
        _paymentRepository = paymentRepository;
        _publisher = publisher;
    }

    public async Task<Result<CreatePaymentResponse>> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _paymentRepository.CreateAsync(request, cancellationToken);
            await _publisher.Publish(new PaymentForRouteApplicationCreatedEvent { PaymentId = response.Id, RouteApplicationId = request.RouteApplicationId }, cancellationToken);
            await _publisher.Publish(new PaymentForRouteCreatedEvent { PaymentId = response.Id, RouteId = request.RouteId }, cancellationToken);

            return Result.Success(response.Adapt<CreatePaymentResponse>());
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return Result.Error(new ErrorList(new List<string> { ex.Message }));
        }
    }
}
