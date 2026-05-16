using System.ComponentModel.DataAnnotations;

namespace DamWebAppApril.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
