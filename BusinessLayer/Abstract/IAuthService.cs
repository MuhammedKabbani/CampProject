using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace BusinessLayer.Abstract
{
	public interface IAuthService
	{
		IDataResult<User> Register(UserForRegisterDto user, string password);
		IDataResult<User> Login(UserForLoginDto user);
		IResult UserExists(string email);
		IDataResult<AccessToken> CreateAccessToken(User user);
	}
}
