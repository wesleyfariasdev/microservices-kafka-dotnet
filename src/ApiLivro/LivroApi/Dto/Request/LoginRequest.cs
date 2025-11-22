namespace LivroApi.Dto.Request;

public record LoginRequest(
    string Email,
    string Password);