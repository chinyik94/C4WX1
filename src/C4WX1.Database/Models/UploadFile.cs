﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class UploadFile
{
    public int UploadFileId { get; set; }

    public string? FileType { get; set; }

    public byte[]? ByteData { get; set; }

    public string? FileName { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
