namespace CMPS278Backend.Models;

public class ApplicationData : BaseDataModel
{
    public virtual ICollection<ApplicationReview> Reviews { get; set; }
}