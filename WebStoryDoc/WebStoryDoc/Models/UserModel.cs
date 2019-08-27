using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebStoryDoc.Models;
using WebStoryDoc.Models.Filters;
using WebStoryDoc.Validation;

namespace WebStoryDoc.Models
{
    public class UserModel : EtityModel<Person>
    {
        
        [DisplayName("Логин")]
        [Required]
        [Login]
        [FastSearch]
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

        public GroupUsers GroupUser { set; get; }

        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { set; get; }

        [DisplayName("Группа пользователей")]
        public long SelectGroupUsersId { set; get; }
        
        public System.Web.Mvc.SelectList GroupUsers { set; get; }
    }
}