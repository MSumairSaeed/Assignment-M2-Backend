using System;
using crud_assignment_m2.models;
using crud_assignment_m2.Models;

namespace crud_assignment_m2.Interfaces
{
	public interface IAuth
	{
        Task<string> Login(UserModel model);
        Task<bool> SignUp(UserModel model);
    }
}

