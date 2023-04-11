namespace CMPS278Backend.Models;

public class ApplicationReview : BaseReviewModel
{
    public virtual ApplicationData Application { get; set; }
}