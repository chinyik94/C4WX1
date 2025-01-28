﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleDescription { get; set; } = null!;

    public string OptionText { get; set; } = null!;

    public string OptionValue { get; set; } = null!;

    public string OptionType { get; set; } = null!;

    public int Ordering { get; set; }

    public DateTime DateCreated { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<GroupRole> GroupRole { get; set; } = new List<GroupRole>();

    public virtual ICollection<UserCategoryRole> UserCategoryRole { get; set; } = new List<UserCategoryRole>();

    public virtual ICollection<UserRole> UserRole { get; set; } = new List<UserRole>();
}
