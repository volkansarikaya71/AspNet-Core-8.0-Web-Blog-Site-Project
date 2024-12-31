using System.Reflection.Metadata.Ecma335;

namespace deneme3.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public bool Exists { get; set; }
    }
}
