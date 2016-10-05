using System.ComponentModel.DataAnnotations;

namespace MyForum.Data.Core.Common.Models
{
    public interface ITKeyEntity<TKey>
    {
        TKey Id { get; set; }
    }
}