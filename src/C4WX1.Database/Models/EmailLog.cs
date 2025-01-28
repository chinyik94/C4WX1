using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class EmailLog
{
    public int EmailLogId { get; set; }

    public string? description { get; set; }

    public string? msgBCC { get; set; }

    public string? msgCC { get; set; }

    public string? msgTo { get; set; }

    public string? msgSubj { get; set; }

    public string? msgBody { get; set; }

    public string? msgFromName { get; set; }

    public string? msgFrom { get; set; }

    public bool? isHtml { get; set; }

    public string? attachmentName { get; set; }

    public bool? isSent { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? smtpServerAddress { get; set; }

    public string? smtpLogin { get; set; }

    public string? smtpPassword { get; set; }

    public string? smtpPort { get; set; }
}
