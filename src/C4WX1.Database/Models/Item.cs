﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Item
{
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

    public virtual ICollection<BillingInvoiceConsumable> BillingInvoiceConsumable { get; set; } = new List<BillingInvoiceConsumable>();

    public virtual Code CategoryID_FKNavigation { get; set; } = null!;

    public virtual ICollection<ItemStock> ItemStock { get; set; } = new List<ItemStock>();

    public virtual Code ItemUnitID_FKNavigation { get; set; } = null!;

    public virtual ICollection<PatientWoundVisitTreatment> PatientWoundVisitTreatment { get; set; } = new List<PatientWoundVisitTreatment>();
}