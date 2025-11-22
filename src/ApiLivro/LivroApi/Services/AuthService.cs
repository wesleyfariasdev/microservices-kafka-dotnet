using BCrypt.Net;
using LivroApi.Data.Repository;
using LivroApi.Domain;
using LivroApi.Dto.Request;
using LivroApi.Dto.Response;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivroApi.Services;

public class AuthService(IUsuarioRepository usuarioRepository,
                         IConfiguration configuration) : IAuthService
{
    private readonly TimeSpan _tokenValidity = TimeSpan.FromMinutes(20);
    private readonly string _jwtKey = configuration["Jwt:Key"]!;

    public async Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        var usuarioExiste = await usuarioRepository.VerificarUsuarioCadastradoPorEmailAsync(request.Email);
        if (!usuarioExiste)
            return null;

        var usuario = await usuarioRepository.ObterUsuarioPorEmailAsync(request.Email);


        if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            return null;

        var token = GenerateJwtToken(usuario);

        return new AuthResponse(token, usuario.Id, usuario.Nome, usuario.Email);
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var existente = await usuarioRepository.VerificarUsuarioCadastradoPorEmailAsync(request.Email);

        if (existente)
            throw new InvalidOperationException("E-mail já cadastrado.");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var usuario = new Usuario(
            nome: request.Nome,
            email: request.Email,
            isActive: true,
            passwordHash: passwordHash
        );

        await usuarioRepository.CriarUsuarioAsync(usuario);

        var token = GenerateJwtToken(usuario);

        return new AuthResponse(token, usuario.Id, usuario.Nome, usuario.Email);
    }

    private string GenerateJwtToken(Usuario usuario)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id),
            new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
            new Claim(JwtRegisteredClaimNames.Name, usuario.Nome),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.UtcNow.Add(_tokenValidity),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
