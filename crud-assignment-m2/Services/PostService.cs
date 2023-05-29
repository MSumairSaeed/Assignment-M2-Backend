        using System;
using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using AutoMapper;
    using crud_assignment_m2.Interfaces;
        using crud_assignment_m2.models;
    using crud_assignment_m2.schemas;
    using Microsoft.EntityFrameworkCore;

        namespace crud_assignment_m2.services
        {
	        public class PostService : IPost
            {
                private readonly PostDBContext _dbContext;
            private readonly IMapper _mapper;
    
            public PostService(PostDBContext dBContext, IMapper mapper)
		        {
                    _dbContext = dBContext;
            _mapper = mapper;
		        }

                public async Task<bool> AddNewPost(PostModel postModel)
                {
                    try
                    { 
                    await _dbContext.Posts.AddAsync(new Post() { PostId = postModel.PostId, Name = postModel.Name, Comments=postModel.Comments }) ;
                    _dbContext.SaveChanges();
                    return true;
                        }
                    catch (Exception ex)
                    {
                        return false;
                    }

                }

                public async Task<PostModel> DeletePost(int postId)
                {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.PostId == postId);
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
            return _mapper.Map<PostModel>(post);
        }
        //IEnumerable<PostModel>
                public async Task<dynamic> GetAllPosts()
                {
            var posts = await _dbContext.Posts.Include(p => p.Comments).ToListAsync();

            //var options = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.IgnoreCycles,
            //    // Add any additional serialization options as needed
            //};

            //// Serialize an object to JSON
            //var jsonString = JsonSerializer.Serialize(posts, options);

            //// Deserialize JSON back to an object
            //var deserializedObject = JsonSerializer.Deserialize<dynamic>(jsonString, options);
            return posts;

        }

        public async Task<dynamic> GetPost(int postId)
                {
            var post = _dbContext.Posts.Where(x => x.PostId == postId).Include(x => x.Comments);
            return post;
        }

                public async Task<PostModel> UpdatePost(int postId, UpdatePostModel postModel)
                {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.PostId == postId);
            post.Name = postModel.Name;
            _dbContext.SaveChanges();
            return _mapper.Map<PostModel>(post);
        }
            }
        }

