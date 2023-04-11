using CMPS278Backend.ModelsDTO.BaseModelDTOs;

namespace CMPS278Backend.ModelsDTO.GameDTOs;

public class GameDataDTO : BaseDataModelDTO
{
    public virtual ICollection<GameReviewDTO> Reviews { get; set; }
}