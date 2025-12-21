using GymMasterSaaS.Application.Common.Models;
using MediatR;

namespace GymMasterSaaS.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<Result<AuthResponse>>
{
    public string RefreshToken { get; set; } = string.Empty;
}
