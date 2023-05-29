using System;
using crud_assignment_m2.models;

namespace crud_assignment_m2.Interfaces
{
	public interface IComment
	{

        Task<IEnumerable<CommentModel>> GetAllComments();
        Task<CommentModel> GetComment(int CommentId);
        Task<bool> AddNewComment(CommentModel commentModel);
        Task<CommentModel> UpdateComment(int commentId, UpdateCommentModel CommentModel);
        Task<CommentModel> DeleteComment(int commentId);
        Task<IEnumerable<CommentModel>> GetAllCommentsByPostId(int postId);

    }
}

