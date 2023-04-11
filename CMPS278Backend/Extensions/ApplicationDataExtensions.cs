using CMPS278Backend.Models;
using CMPS278Backend.ModelsDTO;

namespace CMPS278Backend.Extensions;

public static class ApplicationDataExtensions
{
    public static ApplicationData ToApplicationData(this ApplicationDataDTO data)
    {
        ApplicationData appData = data.ToBaseDataModel<ApplicationData>();
        appData.Reviews = data.Reviews.Select(review => review.ToApplicationReview()).ToList();
        return appData;
    }
    
    public static ApplicationDataDTO ToApplicationDataDTO(this ApplicationData data)
    {
        ApplicationDataDTO appData = data.ToBaseDataModelDTO<ApplicationDataDTO>();
        appData.Reviews = data.Reviews.Select(review => review.ToApplicationReviewDTO()).ToList();
        return appData;
    }
}