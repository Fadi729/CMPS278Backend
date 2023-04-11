namespace CMPS278Backend.Models.Games;

public class GameReview : BaseReviewModel
{
    public virtual GameData Game { get; set; }
}