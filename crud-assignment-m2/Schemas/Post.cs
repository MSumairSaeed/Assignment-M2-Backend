namespace crud_assignment_m2.schemas
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Name { get; set; }

        public virtual List<Comment>? Comments { get; set; }
    }
}