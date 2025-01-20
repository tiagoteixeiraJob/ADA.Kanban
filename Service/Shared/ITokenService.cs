using Model.Dto;

namespace Service.Shared
{
    public interface ITokenService
    {
        string GenerateToken(LoginDto loginDto);
    }
}
