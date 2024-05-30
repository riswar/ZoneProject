using System.ComponentModel.DataAnnotations;

namespace Zone.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
