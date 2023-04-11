namespace CMPS278Backend.ModelsDTO.BaseModelDTOs;

public abstract class BaseReviewModelDTO
{
    public string  Id        { get; set; }
    public string? UserName  { get; set; }
    public string? UserImage { get; set; }
    public string? Date      { get; set; }
    public double?  Score     { get; set; }
    public string? ScoreText { get; set; }
    public string? Url       { get; set; }
    public string? Title     { get; set; }
    public string? Text      { get; set; }
    public string? ReplyDate { get; set; }
    public string? ReplyText { get; set; }
    public string? Version   { get; set; }
    public long?    ThumbsUp  { get; set; }
}