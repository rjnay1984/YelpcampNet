using System.ComponentModel.DataAnnotations;

namespace YelpcampNet.ApplicationCore.Entities
{
    public class Campground : BaseEntity
    {
        [Required]
        public string? Title { get; set; }
        public string? HeaderImage { get; set; }
        public string[]? SlideshowImages { get; set; }
        public string? Teaser { get; set; }
        public string? Description { get; set; }
        public List<Comment> Comments { get; set; }
        public string UserId { get; set; }
    }
}
