using System;
using System.Collections.Generic;

namespace MessageApp.Enetities;

public partial class Message
{
    public Guid Id { get; set; }

    public string Text { get; set; } = null!;

    public DateTime? Createdat { get; set; }

    public Guid Studentid { get; set; }

    public virtual Student Student { get; set; } = null!;
}
