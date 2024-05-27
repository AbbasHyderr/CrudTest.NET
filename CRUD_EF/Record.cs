using System;
using System.Collections.Generic;

namespace TestCrud.CRUD_EF;

public partial class Record
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }
}
