using CMPS278Backend.ModelsDTO.BaseModelDTOs;

namespace CMPS278Backend.ModelsDTO;

public class ApplicationDataDTO : BaseDataModelDTO
{
    public virtual ICollection<ApplicationReviewDTO> Reviews { get; set; }
}