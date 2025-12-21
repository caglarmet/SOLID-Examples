using GymMasterSaaS.Application.Features.Auth.Commands.Login;
using GymMasterSaaS.Application.Features.Auth.Commands.RefreshToken;
using GymMasterSaaS.Application.Features.Auth.Commands.Register;
using MediatR;

namespace GymMasterSaaS.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth").WithTags("Authentication");

        group.MapPost("/register", async (RegisterCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess
                ? Results.Ok(result.Data)
                : Results.BadRequest(new { error = result.Error, errors = result.Errors });
        })
        .WithName("Register")
        .Produces(200)
        .Produces(400);

        group.MapPost("/login", async (LoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess
                ? Results.Ok(result.Data)
                : Results.BadRequest(new { error = result.Error, errors = result.Errors });
        })
        .WithName("Login")
        .Produces(200)
        .Produces(400);

        group.MapPost("/refresh-token", async (RefreshTokenCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess
                ? Results.Ok(result.Data)
                : Results.BadRequest(new { error = result.Error, errors = result.Errors });
        })
        .WithName("RefreshToken")
        .Produces(200)
        .Produces(400);
    }
}
