using AutoMapper;
using RealEstate.Services.Domains.Users.Models;
using RealEstate.Services.Domains.Users.Repositories;
using RealEstate.Services.EntityFramework.Entities;
using RealEstate.Services.Repository.Entity;

namespace RealEstate.Services.Domains.Users
{
	public class UserService : IUserService
	{

		private readonly IRepository<User> _userRepository;
		private readonly IMapper _mapper;

		public UserService(IRepository<User> userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<bool> Add(AddUserRequestModel request)
		{
			var user = _userRepository.GetAll(x => x.Email == request.Email || x.Phone == request.Phone).FirstOrDefault();
			if (user == null)
			{
				var result = await _userRepository.Create(new User
				{
					FullName = request.FullName,
					Password = request.Password,
					Email = request.Email,
					Phone = request.Phone,
					UserType = request.UserType,
				});
				return result;
			}
			return false;
		}

		public async Task<bool> Delete(int id)
		{
			var result = await _userRepository.Delete(id);
			return result;
		}

		public List<UserListItemModel> GetAll()
		{
			var user = _userRepository.GetAll();
			return _mapper.Map<List<UserListItemModel>>(user);

		}

		public async Task<List<UserListItemModel>> GetAllUserByAdmin(GetAllUserByAdminRequestModel request)
		{
			var user = await _userRepository.GetById(request.UserId);
			if (user.UserType == UserType.Admin)
			{
				var response = _userRepository.GetAll();
				return _mapper.Map<List<UserListItemModel>>(response);
			}
			return new List<UserListItemModel>();
		}

		public async Task<GetUserReponseModel> GetById(int id)
		{
			var user = await _userRepository.GetById(id);
			return _mapper.Map<GetUserReponseModel>(user);
		}

		public async Task<bool> IsAdmin(int id)
		{
			var user = await _userRepository.GetById(id);
			if (user.UserType == UserType.Admin)
			{
				return true;
			}
			return false;
		}

		public async Task<LoginResponseModel> Login(LoginRequestModel request)
		{

			var user = _userRepository.GetAll(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();
			if (user != null)
			{
				var loginResponse = _mapper.Map<LoginResponseModel>(user);
				return loginResponse;
			}

			return new LoginResponseModel();
		}

		public async Task<bool> SendResetPassword(ResetPasswordRequest requset)
		{
			var user = _userRepository.GetAll(x=> x.Email==requset.Email && x.Phone==requset.Phone).FirstOrDefault();
			if (user != null)
			{
				var newPassword = MailHelper.SendMail(requset.Email);
				user.Password = newPassword;
				await _userRepository.Update(user.Id, user);
				return true;
			}
			return false;
		}

		public async Task<bool> Update(UpdateUserRequestModel request)
		{
			var user = new User
			{
				Id = request.Id,
				FullName = request.FullName,
				Password = request.Password,
				Email = request.Email,
				UserType = request.UserType,
				Phone = request.Phone,
			};
			var result = await _userRepository.Update(request.Id, user);
			return result;
		}

	}
}
