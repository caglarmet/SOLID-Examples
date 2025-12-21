using GymMasterSaaS.Application.Common.Models;
using MediatR;

namespace GymMasterSaaS.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<Result<AuthResponse>>
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string TenantName { get; set; } = string.Empty;
}
