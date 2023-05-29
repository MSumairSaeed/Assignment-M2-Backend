using System;
using System.ComponentModel.Design;
using AutoMapper;
using crud_assignment_m2.Interfaces;
using crud_assignment_m2.models;
using crud_assignment_m2.schemas;
using Microsoft.EntityFrameworkCore;

namespace crud_assignment_m2.services
{
	public class CommentService:IComment
	{
        private readonly PostDBContext _dbContext;
        private readonly IMapper _mapper;

        public CommentService(PostDBContext dBContext, IMapper mapper)
		{
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public async Task<bool> AddNewComment(CommentModel commentModel)
        {
            try { 
            _dbContext.Add(new Comment() {
                Content = commentModel.Content, PostId = commentModel.PostId, Title = commentModel.Title
            });
            _dbContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<CommentModel> DeleteComment(int commentId)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
            return _mapper.Map<CommentModel>(comment);
        }

        public async Task<IEnumerable<CommentModel>> GetAllComments()
        {
            var comments = await _dbContext.Comments.ToListAsync();
            return comments.Select(x => _mapper.Map<CommentModel>(x));
        }

        public Task<IEnumerable<CommentModel>> GetAllCommentsByPostId(int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentModel> GetComment(int commentId)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);
            return _mapper.Map<CommentModel>(comment);
        }

        public async Task<CommentModel> UpdateComment(int commentId, UpdateCommentModel CommentModel)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);
            comment.Content = CommentModel.Content;
            comment.Title = CommentModel.Title;
            _dbContext.SaveChanges();
            return _mapper.Map<CommentModel>(comment);
        }
    }
}

