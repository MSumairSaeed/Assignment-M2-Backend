using System;
using crud_assignment_m2.schemas;

namespace crud_assignment_m2.models
{
	public class PostModel
	{
        public int PostId { get; set; }
        public string? Name { get; set; }
        public List<Comment>? Comments { get; set; }   
	}
}

