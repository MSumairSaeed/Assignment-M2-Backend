using System;
namespace crud_assignment_m2.models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int PostId { get; set; }
    }
}

