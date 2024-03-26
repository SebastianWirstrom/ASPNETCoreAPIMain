using Infrastructure.Entities;

namespace WebApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Price { get; set; }
        public string? DiscountPrice { get; set; }
        public string? Hours { get; set; }
        public bool IsBestSeller { get; set; }
        public string? LikesInNumbers { get; set; }
        public string? LikesInPercent { get; set; }
        public string? Author { get; set; }

        public static implicit operator Course(CourseEntity courseEntity)
        {
            return new Course
            {
                Id = courseEntity.Id,
                Title = courseEntity.Title,
                Price = courseEntity.Price,
                DiscountPrice = courseEntity.DiscountPrice,
                Hours = courseEntity.Hours,
                IsBestSeller = courseEntity.IsBestSeller,
                LikesInNumbers = courseEntity.LikesInNumbers,
                LikesInPercent = courseEntity.LikesInPercent,
                Author = courseEntity.Author
            };
        }
    }
}