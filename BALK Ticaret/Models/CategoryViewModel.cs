using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CategoryViewModel : BaseEntityViewModel
    {
        public string Name { get; set; }

        public List<ProductViewModel>? ProductViewModels { get; set; }



    }
}
