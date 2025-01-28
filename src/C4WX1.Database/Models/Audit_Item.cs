﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Item
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int ItemID { get; set; }

    public string ItemName { get; set; } = null!;

    public int CategoryID_FK { get; set; }

    public int ItemUnitID_FK { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public bool? AvailableInBilling { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
