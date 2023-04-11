using CMPS278Backend.Models;
using CMPS278Backend.ModelsDTO;

namespace CMPS278Backend.Extensions;

public static class ApplicationDataExtensions
{
    public static ApplicationData ToApplicationData(this ApplicationDataDTO data)
    {
        ApplicationData appData = data.ToBaseDataModel<ApplicationData>();
        appData.Reviews = data.Reviews.Select(review => review.ToApplicationReview(data.AppId)).ToList();
        return appData;
    }
}