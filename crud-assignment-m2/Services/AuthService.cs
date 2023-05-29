using System;
using AutoMapper;
using crud_assignment_m2.Interfaces;
using crud_assignment_m2.Models;
using crud_assignment_m2.schemas;

namespace crud_assignment_m2.Services
{
	public class AuthService: IAuth
	{
        private IOktaToken _oktaTokenService;
        private readonly PostDBContext _dbContext;
        private readonly IMapper _mapper;

        public AuthService(IOktaToken oktaTokenService, IMapper mapper, PostDBContext dBContext)
		{
            _oktaTokenService = oktaTokenService;
            _mapper = mapper;
            _dbContext = dBContext;
        }

        public async Task<string> Login(UserModel model)
        {

            var userFound = _dbContext.Users.Where(x => x.Email == model.Email && x.Password == model.Password).ToList();
            if (userFound?.Count > 0)
            {
                return await _oktaTokenService.GetToken();
            }
            return "User Not Found";
        }

        public async Task<bool> SignUp(UserModel model)
        {
            var user =await _dbContext.Users.AddAsync(new Schemas.User() {  Name=model.Name, Email=model.Email, Password=model.Password});
            _dbContext.SaveChanges();
            return true;
        }
    }
}

