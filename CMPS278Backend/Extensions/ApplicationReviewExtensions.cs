using CMPS278Backend.Models;
using CMPS278Backend.ModelsDTO;

namespace CMPS278Backend.Extensions;

public static class ApplicationReviewExtensions
{
    public static ApplicationReview ToApplicationReview(this ApplicationReviewDTO review, string appId)
    {
        return review.ToBaseReviewModel<ApplicationReview>();
    }
}