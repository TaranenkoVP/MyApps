using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Data.Core.Common.Models
{
    public interface ITKeyEntity<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }
}
