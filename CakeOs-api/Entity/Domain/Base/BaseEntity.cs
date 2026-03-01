namespace CakeOS.Entity.Domain.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
