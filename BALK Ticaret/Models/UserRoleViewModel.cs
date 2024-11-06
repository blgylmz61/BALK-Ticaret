using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class UserRoleViewModel : BaseEntityViewModel
    {
        public string Role { get; set; }
        public string Description { get; set; }
        public List<UserViewModel> UserViewModels { get; set; }
    }
}
