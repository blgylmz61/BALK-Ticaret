namespace BALK_Ticaret.Models
{
    public class GenderViewModel:BaseEntityViewModel
    {
        public string Name { get; set; }
        public UserDetailViewModel ?UserDetailViewModel { get; set; }
    }
}
