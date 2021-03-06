﻿using System.ComponentModel.DataAnnotations;

namespace MicroB2c.Web.Areas.Admin.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }
}