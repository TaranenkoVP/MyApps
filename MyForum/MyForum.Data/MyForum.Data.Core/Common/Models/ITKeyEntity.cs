using System.ComponentModel.DataAnnotations;

namespace MyForum.Data.Core.Common.Models
{
    public interface ITKeyEntity<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }
}