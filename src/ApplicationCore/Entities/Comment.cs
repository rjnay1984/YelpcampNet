using System.ComponentModel.DataAnnotations;

namespace YelpcampNet.ApplicationCore.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int CampgroundId { get; set; }
        [Required]
        public Campground Campground { get; set; }
        public string UserId { get; set; }
    }
}