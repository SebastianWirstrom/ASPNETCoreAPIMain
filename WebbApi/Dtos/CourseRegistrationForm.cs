﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos;

public class CourseRegistrationForm
{
    [Required]
    public string Title { get; set; } = null!;

    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool IsBestSeller { get; set; } = false;
    public string? LikesInNumbers { get; set; }
    public string? LikesInPercent { get; set; }
    public string? Author { get; set; }
}
