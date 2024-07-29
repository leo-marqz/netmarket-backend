

using System;

namespace DOMAIN.Common;

public class ModelBase
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = "System";
    public DateTime DateModified { get; set; } = DateTime.UtcNow;
    public string ModifiedBy { get; set; } = "System";
}

