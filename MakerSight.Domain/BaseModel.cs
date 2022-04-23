using System;
namespace MakerSight.Domain;
public class BaseModel
{
    // this base class contains basic auditing fields.
    // inheriting other domain classes from this will allow all of them to have these auditing fields just in case.
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
