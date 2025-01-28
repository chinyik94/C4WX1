using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class ItemStock
{
    public int ItemStockID { get; set; }

    public int ItemID_FK { get; set; }

    public int Quantity { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public virtual Item ItemID_FKNavigation { get; set; } = null!;
}
