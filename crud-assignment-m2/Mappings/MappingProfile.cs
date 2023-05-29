using System;
using AutoMapper;
using crud_assignment_m2.models;
using crud_assignment_m2.Models;
using crud_assignment_m2.schemas;
using crud_assignment_m2.Schemas;

namespace crud_assignment_m2.mappings
{
	public class MappingProfile: Profile
	{
		public MappingProfile()
		{
            CreateMap<PostModel, Post>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<CommentModel, Comment>().ReverseMap();
        }
    }
}

