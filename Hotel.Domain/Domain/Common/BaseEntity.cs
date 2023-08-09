public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; } = false;
}
