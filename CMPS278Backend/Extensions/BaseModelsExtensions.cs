using CMPS278Backend.Models;
using CMPS278Backend.ModelsDTO.BaseModelDTOs;

namespace CMPS278Backend.Extensions;

public static class BaseModelsExtensions
{
    public static T ToBaseDataModel<T>(this BaseDataModelDTO data) where T : BaseDataModel, new()
    {
        return new T
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
        };
    }

    public static T ToBaseDataModelDTO<T>(this BaseDataModel data) where T : BaseDataModelDTO, new()
    {
        return new T
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
        };
    }

    public static T ToBaseReviewModel<T>(this BaseReviewModelDTO review) where T : BaseReviewModel, new()
    {
        return new T
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

    public static T ToBaseReviewModelDTO<T>(this BaseReviewModel review) where T : BaseReviewModelDTO, new()
    {
        return new T
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