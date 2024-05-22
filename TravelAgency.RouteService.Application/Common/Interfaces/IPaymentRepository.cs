using TravelAgency.RouteService.Application.Payments.Commands;
using TravelAgency.RouteService.Application.Payments.Queries;
using TravelAgency.RouteService.Domain.Entities;

namespace TravelAgency.RouteService.Application.Common.Interfaces;
public interface IPaymentRepository
{
    Task<Payment> CreateAsync(CreatePaymentRequest request, CancellationToken cancellationToken);
    Task<IEnumerable<Payment>> ListByDatesAsync(ListPaymentRequest request, CancellationToken cancellationToken);   
}
