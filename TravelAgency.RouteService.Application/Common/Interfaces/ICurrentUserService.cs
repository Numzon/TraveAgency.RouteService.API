﻿namespace TravelAgency.RouteService.Application.Common.Interfaces;
public interface ICurrentUserService
{
    string? AccessToken { get; }
    string? Id { get; }
}
