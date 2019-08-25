using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStoryDoc.Models
{
    public class GroupUsersModel : EtityModel<GroupUsers>
    {
        [DisplayName("Название группы")]
        [Required]
        public string Name { set; get; }
    }
}