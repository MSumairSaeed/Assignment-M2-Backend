using System;
using crud_assignment_m2.models;

namespace crud_assignment_m2.Interfaces
{
	public interface IPost
	{
        Task<dynamic> GetAllPosts();
        Task<dynamic> GetPost(int postId);
        Task<bool> AddNewPost(PostModel postModel);
        Task<PostModel> UpdatePost(int postId, UpdatePostModel postModel);
        Task<PostModel> DeletePost(int postId);
	}
}

