using CMPS278Backend.Models;
using CMPS278Backend.ModelsDTO;

namespace CMPS278Backend.Extensions;

public static class ApplicationReviewExtensions
{
    public static ApplicationReview ToApplicationReview(this ApplicationReviewDTO review, string appId)
    {
        return new ApplicationReview
        {
            Id        = review.Id,
            UserName  = review.UserName,
            UserImage = review.UserImage,
            Date      = review.Date,
            Score     = review.Score,
            ScoreText = review.ScoreText,
            Url       = review.Url,
            Title     = review.Title,
            Text      = review.Text,
            ReplyDate = review.ReplyDate,
            ReplyText = review.ReplyText,
            Version   = review.Version,
            ThumbsUp  = review.ThumbsUp
        };
    }
}