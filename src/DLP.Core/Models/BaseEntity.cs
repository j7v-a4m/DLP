using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Core.Models
{
    public class BaseEntity
    {
        public BaseEntity(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
    }
}
