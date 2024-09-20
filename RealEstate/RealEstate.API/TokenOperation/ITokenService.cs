using RealEstate.API.Models.JwtAuth;

namespace RealEstate.API.Mahmut
{
	public interface ITokenService
	{
		public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
	}
}
