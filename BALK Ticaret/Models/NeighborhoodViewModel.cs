using BLL.Dtos;

namespace BALK_Ticaret.Models
{
    public class NeighborhoodViewModel : BaseEntityViewModel
    {
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public DistrictViewModel District { get; set; }
    }
}
