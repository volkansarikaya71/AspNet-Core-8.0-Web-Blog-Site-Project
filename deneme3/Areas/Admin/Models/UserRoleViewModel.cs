namespace deneme3.Areas.Admin.Models
{
    public class UserRoleViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleAssignViewModel> Roles { get; set; }
    }
}
