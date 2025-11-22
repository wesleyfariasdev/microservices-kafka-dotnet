namespace LivroApi.Dto.Response;

public record AuthResponse(
    string Token,
    string UserId,
    string Nome,
    string Email);