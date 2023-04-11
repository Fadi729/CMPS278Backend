using CMPS278Backend.Models;
using CMPS278Backend.ModelsDTO;

namespace CMPS278Backend.Extensions;

public static class ApplicationReviewExtensions
{
    public static ApplicationReview ToApplicationReview(this ApplicationReviewDTO review)
    {
        return review.ToBaseReviewModel<ApplicationReview>();
    }
    
    public static ApplicationReviewDTO ToApplicationReviewDTO(this ApplicationReview review)
    {
        return review.ToBaseReviewModelDTO<ApplicationReviewDTO>();
    }
}