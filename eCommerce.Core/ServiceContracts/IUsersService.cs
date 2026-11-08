

using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUsersService
    {
        Task<AuthenticationResponse?> Login(LoginRequest loginrequest);
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);

    }
}