using CMPS278Backend.Models.Games;
using CMPS278Backend.ModelsDTO.GameDTOs;

namespace CMPS278Backend.Extensions;

public static class GameReviewExtensions
{
    public static GameReview ToGameReview(this GameReviewDTO review)
    {
        return review.ToBaseReviewModel<GameReview>();
    }
}