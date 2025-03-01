namespace EcommerceAPI.Controllers.AuthController.Services
{
    public interface IJwtService
    {
        string GenerateToken(Guid userId, string role);
    }
}
