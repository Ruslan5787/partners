using System;
using System.Collections.Generic;

namespace Plants_App;

public partial class MaterialType
{
    public int Id { get; set; }

    public string MaterialType1 { get; set; } = null!;

    public string ProcentBrakaMateriala { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
