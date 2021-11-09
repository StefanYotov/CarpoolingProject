﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolingProject.Models.EntityModels
{
    public class Role
    {

        public int RoleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
