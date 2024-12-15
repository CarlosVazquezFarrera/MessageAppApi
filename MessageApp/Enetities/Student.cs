using System;
using System.Collections.Generic;

namespace MessageApp.Enetities;

public partial class Student
{
    public Guid Id { get; set; }

    public string Clave { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
