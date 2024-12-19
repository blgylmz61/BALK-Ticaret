namespace BALK_Ticaret.Models
{
    public class GenderViewModel:BaseEntityViewModel
    {
        public string Name { get; set; }
        public UserDetailViewModel ?UserDetail { get; set; }
    }
}
