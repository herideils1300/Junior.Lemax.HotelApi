using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph.InformationProtection.ThreatAssessmentRequests.Item.Results;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.IdentityModel.Tokens;

public static class AutoAuthHandler
{
    public static string? HandleAuthenticateAsync(IConfiguration configuration)
    {


        var jwtIssuer = configuration["Jwt:issuer"];
        var jwtKey = configuration["Jwt:key"];

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "AutoUser"),
            new Claim(ClaimTypes.Role, "Admin"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtIssuer,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        string stringToken = new JwtSecurityTokenHandler().WriteToken(token);

        return stringToken;

    }
}
