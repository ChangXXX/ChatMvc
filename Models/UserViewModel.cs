
using System.ComponentModel.DataAnnotations;

namespace ChatMvc.Models;

public class UserViewModel
{
    [Required(ErrorMessage = "이름을 입력해주세요")]
    public string Name { get; set; }

    [Required(ErrorMessage = "비밀번호를 입력해주세요")]
    public string Pwd { get; set;}
}