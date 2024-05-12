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
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public Course Course { get; set; }
        public User Student { get; set; }
    }
}
