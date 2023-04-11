namespace CMPS278Backend.Models.Games;

public class GameData : BaseDataModel
{
    public virtual ICollection<GameReview> Reviews { get; set; }
}