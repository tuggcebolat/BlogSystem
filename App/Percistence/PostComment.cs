namespace App.Percistence
{
    public class PostComment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        = DateTime.Now;
        public DateTime Updated { get; set; }
        public Post Post { get; set; }

    }
}
