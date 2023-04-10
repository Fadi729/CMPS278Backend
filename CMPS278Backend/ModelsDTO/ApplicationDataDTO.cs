namespace CMPS278Backend.ModelsDTO;

public class ApplicationDataDTO
{
    public string                    AppId                    { get; set; }
    public string                    Url                      { get; set; }
    public string?                   Title                    { get; set; }
    public string?                   Summary                  { get; set; }
    public string?                   Developer                { get; set; }
    public string?                   DeveloperId              { get; set; }
    public string?                   Icon                     { get; set; }
    public float?                    Score                    { get; set; }
    public string?                   ScoreText                { get; set; }
    public string?                   PriceText                { get; set; }
    public bool?                     Free                     { get; set; }
    public string?                   Description              { get; set; }
    public string?                   DescriptionHTML          { get; set; }
    public string?                   Installs                 { get; set; }
    public int?                      MinInstalls              { get; set; }
    public int?                      MaxInstalls              { get; set; }
    public int?                      Ratings                  { get; set; }
    public int?                      ReviewsCount             { get; set; }
    public IDictionary<string, int>? Histogram                { get; set; }
    public float?                    Price                    { get; set; }
    public string?                   Currency                 { get; set; }
    public bool?                     Available                { get; set; }
    public bool?                     OffersIAP                { get; set; }
    public string?                   IAPRange                 { get; set; }
    public string?                   Size                     { get; set; }
    public string?                   AndroidVersion           { get; set; }
    public string?                   AndroidVersionText       { get; set; }
    public string?                   DeveloperInternalID      { get; set; }
    public string?                   DeveloperEmail           { get; set; }
    public string?                   DeveloperWebsite         { get; set; }
    public string?                   DeveloperAddress         { get; set; }
    public string?                   Genre                    { get; set; }
    public string?                   GenreId                  { get; set; }
    public string?                   FamilyGenre              { get; set; }
    public string?                   FamilyGenreId            { get; set; }
    public string?                   HeaderImage              { get; set; }
    public IList<string>?            Screenshots              { get; set; }
    public string?                   Video                    { get; set; }
    public string?                   VideoImage               { get; set; }
    public string?                   ContentRating            { get; set; }
    public string?                   ContentRatingDescription { get; set; }
    public bool?                     AdSupported              { get; set; }
    public string?                   Released                 { get; set; }
    public long?                     Updated                  { get; set; }
    public string?                   Version                  { get; set; }
    public string?                   RecentChanges            { get; set; }
    public IList<string>?            Comments                 { get; set; }

    public virtual ICollection<ApplicationReviewDTO> Reviews { get; set; }
}