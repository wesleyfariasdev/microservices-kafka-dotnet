using LivroApi.Dto.Request;
using LivroApi.Dto.Response;

namespace LivroApi.Services;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse?> LoginAsync(LoginRequest request);
}

