using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebStoryDoc.Models;
using WebStoryDoc.Validation;

namespace WebStoryDoc.Models
{
    public class UserModel : EtityModel<Person>
    {
        
        [DisplayName("Логин")]
        [Required]
        [Login]
        public string Login { set; get; }

        [DisplayName("Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [DisplayName("Повторите пароль")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public GroupUsers GroupUsers { set; get; }
    }
}