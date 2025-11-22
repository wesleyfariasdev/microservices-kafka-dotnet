namespace LivroApi.Dto.Request;

public record RegisterRequest(
    string Nome,
    string Email,
    string Password);
