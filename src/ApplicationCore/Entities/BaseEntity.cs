namespace YelpcampNet.ApplicationCore.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
