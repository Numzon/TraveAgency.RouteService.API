using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Application.Common.Models;

namespace TravelAgency.RouteService.Application.Payments.Queries;
public sealed record ListPaymentResponse(IEnumerable<PaymentDto> Payments);

public sealed record ListPaymentRequest(DateOnly From, DateOnly To) : IRequest<Result<ListPaymentResponse>>;

public sealed class ListPaymentHandler : IRequestHandler<ListPaymentRequest, Result<ListPaymentResponse>>
{
    private readonly IPaymentRepository _paymentRepository;

    public ListPaymentHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Result<ListPaymentResponse>> Handle(ListPaymentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _paymentRepository.ListByDatesAsync(request, cancellationToken);
            return Result.Success(new ListPaymentResponse(response.Adapt<IEnumerable<PaymentDto>>()));
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return Result.Error(new ErrorList(new List<string> { ex.Message }));
        }
    }
}
