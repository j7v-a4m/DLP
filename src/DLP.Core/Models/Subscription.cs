using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Core.Models
{
    public class Subscription
    {
        public Guid CourseId { get; }
        public Guid StudentId { get; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; }
        [ForeignKey(nameof(StudentId))]
        public User Student { get; }
    }
}
