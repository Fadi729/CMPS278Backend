using CMPS278Backend.Models;
using CMPS278Backend.ModelsDTO;

namespace CMPS278Backend.Extensions;

public static class ApplicationDataExtensions
{
    public static ApplicationData ToApplicationData(this ApplicationDataDTO data)
    {
        return new ApplicationData
        {
            AppId                    = data.AppId,
            Url                      = data.Url,
            Title                    = data.Title,
            Summary                  = data.Summary,
            Developer                = data.Developer,
            DeveloperId              = data.DeveloperId,
            Icon                     = data.Icon,
            Score                    = data.Score,
            ScoreText                = data.ScoreText,
            PriceText                = data.PriceText,
            Free                     = data.Free,
            Description              = data.Description,
            DescriptionHTML          = data.DescriptionHTML,
            Installs                 = data.Installs,
            MinInstalls              = data.MinInstalls,
            MaxInstalls              = data.MaxInstalls,
            Ratings                  = data.Ratings,
            ReviewsCount             = data.ReviewsCount,
            Histogram                = data.Histogram,
            Price                    = data.Price,
            Currency                 = data.Currency,
            Available                = data.Available,
            OffersIAP                = data.OffersIAP,
            IAPRange                 = data.IAPRange,
            Size                     = data.Size,
            AndroidVersion           = data.AndroidVersion,
            AndroidVersionText       = data.AndroidVersionText,
            DeveloperInternalID      = data.DeveloperInternalID,
            DeveloperEmail           = data.DeveloperEmail,
            DeveloperWebsite         = data.DeveloperWebsite,
            DeveloperAddress         = data.DeveloperAddress,
            Genre                    = data.Genre,
            GenreId                  = data.GenreId,
            FamilyGenre              = data.FamilyGenre,
            FamilyGenreId            = data.FamilyGenreId,
            HeaderImage              = data.HeaderImage,
            Screenshots              = data.Screenshots,
            Video                    = data.Video,
            VideoImage               = data.VideoImage,
            ContentRating            = data.ContentRating,
            ContentRatingDescription = data.ContentRatingDescription,
            AdSupported              = data.AdSupported,
            Released                 = data.Released,
            Updated                  = data.Updated,
            Version                  = data.Version,
            RecentChanges            = data.RecentChanges,
            Comments                 = data.Comments,
            Reviews                  = data.Reviews.Select(review => review.ToApplicationReview(data.AppId)).ToList()
        };
    }
}