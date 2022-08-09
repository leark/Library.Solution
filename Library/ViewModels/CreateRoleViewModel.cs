using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
  public class CreateRoleViewModel
  {
    [Required]
    public string RoleName { get; set; }
  }
}