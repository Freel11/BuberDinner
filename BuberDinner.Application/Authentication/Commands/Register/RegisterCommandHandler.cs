using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Authentication.Common;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IJwtTokenGenerator jwtTokenGenerator,
    IUserRepository userRepository) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create a new user (generate unique ID) & Persist to db
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        // 3. create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
